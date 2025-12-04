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
        public static async Task<Paginate<T>> PaginateAndMap<T>(
            IQueryable<T> query,
            int pageNumber,
            int pageSize)
        {
            var totalItems = await query.CountAsync();
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new Paginate<T>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalItems,
                Items = items
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
            var roles = user.UserRole
                .Select(ur => ur.Role.Name)
                .ToList();
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                new Claim(ClaimTypes.Name, user.Username),

            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
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
