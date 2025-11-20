using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API.Controllers
{
    public class  RoleQuery
    {
        private readonly DB _context;
        public RoleQuery(DB context)
        {
            _context = context;
        }
        public async Task<Role?> GetRoleByIDAsync(int ID)
        {
            return await _context.Role
                .AsNoTracking()
                .SingleOrDefaultAsync(r => r.ID == ID);
        }
        public async  Task<Role?> PatchRoleByIDAsync(int ID)
        {
            return await _context.Role
               .SingleOrDefaultAsync(r => r.ID == ID);
        }
        public IQueryable<Role?> PaginatedRoles(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var query = _context.Role
                    .AsNoTracking()
                    .Where(r => r.Name.Contains(searchTerm))
                    .OrderByDescending(r => r.ID)
                    .AsQueryable();

                return query;
            }
            else
            {
                var query = _context.Role
                    .AsNoTracking()
                    .OrderByDescending(r => r.ID)
                    .AsQueryable();

                return query;
            }
        } 
        public async Task<List<Role>> ListedRoles(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                return await _context.Role
                    .AsNoTracking()
                    .Where(r => r.Name.Contains(searchTerm))
                    .OrderByDescending(r => r.ID)
                    .ToListAsync();
            } else
            {
                return await _context.Role
                    .AsNoTracking()
                    .OrderByDescending(r => r.ID)
                    .ToListAsync();
            }
        }
    }
}