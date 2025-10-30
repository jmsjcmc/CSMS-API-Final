using AutoMapper;
using AutoMapper.QueryableExtensions;
using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
    }
}
