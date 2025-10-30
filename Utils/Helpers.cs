using AutoMapper;
using AutoMapper.QueryableExtensions;
using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CSMS_API.Utils
{
    public static class PresentDateTimeFetcher
    {
        public static DateTime FetchPresentDateTime()
        {
            try
            {
                var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Manila");
                return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
            }
            catch
            {
                var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Singapore Standad Time");
                return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
            }
        }
    }
    public static class PaginationHelper
    {
        public static async Task<List<TDestination>> PaginatedAndProjectAsync<TSource, TDestination>(
            IQueryable<TSource> query,
            int pageNumber,
            int pageSize,
            IMapper mapper)
        {
            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<TDestination>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
        public static async Task<Paginate<TDestination>> PaginateAndMapAsync<TSource, TDestination>(
            IQueryable<TSource> query,
            int pageNumber,
            int pageSize,
            IMapper mapper)
        {
            var totalCount = await query.CountAsync();
            var items = await PaginatedAndProjectAsync<TSource, TDestination>(query, pageNumber, pageSize, mapper);
            return PaginatedResponse(items, totalCount, pageNumber, pageSize);
        }
        public static Paginate<T> PaginatedResponse<T>(
            List<T> items,
            int totalCount,
            int pageNumber,
            int pageSize)
        {
            return new Paginate<T>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }
    public class AuthenticationHelper
    {
        private readonly IConfiguration _config;
        public AuthenticationHelper(IConfiguration config)
        {
            _config = config;
        }
        public static int GetUserIDAsync(ClaimsPrincipal user)
        {
            if (user == null)
                return 0;
            var value = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (int.TryParse(value, out int userID))
            {
                return userID;
            }
            return 0;
        }
        public string GenerateAccessToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]!);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                //new Claim(ClaimTypes.Role, user.UserRole.)
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(8),
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
