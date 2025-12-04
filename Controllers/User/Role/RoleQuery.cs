using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API.Controllers
{
    public class  RoleQuery : RoleQueriesInterface
    {
        private readonly DB _context;
        public RoleQuery(DB context)
        {
            _context = context;
        }
        public async Task<Role?> PatchRoleByIDAsync(int ID)
        {
            return await _context.Role
                .SingleOrDefaultAsync(R => R.ID == ID);
        }
        public async Task<RoleOnlyResponse?> RoleOnlyResponseByIDAsync(int ID)
        {
            return await _context.Role
                .AsNoTracking()
                .Where(R => R.ID == ID)
                .Select(R => new RoleOnlyResponse
                {
                    ID = R.ID,
                    Name = R.Name,
                    CreatedOn = R.CreatedOn,
                    RecordStatus = R.RecordStatus
                }).SingleOrDefaultAsync();
        }
        public IQueryable<RoleOnlyResponse> RoleOnlyResponseAsync(string? searchTerm, RecordStatus? status)
        {
            var query = _context.Role
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(R => R.Name.Contains(searchTerm));
            }
            if (status.HasValue)
            {
                query = query.Where(R => R.RecordStatus == status);
            }

            return query
                .OrderByDescending(R => R.ID)
                .Select(R => new RoleOnlyResponse
                {
                    ID = R.ID,
                    Name = R.Name,
                    CreatedOn = R.CreatedOn,
                    RecordStatus = R.RecordStatus
                });
        }
    }
}