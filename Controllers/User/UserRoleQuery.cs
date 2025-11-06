using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API.Controllers
{
    public class UserRoleQuery
    {
        private readonly DB _context;
        public UserRoleQuery(DB context)
        {
            _context = context;
        }
        public async Task<UserRole?> GetUserRoleByIDAsync(int ID)
        {
            return await _context.UserRole
                .AsNoTracking()
                .Where(ur => ur.UserID == ID || ur.RoleID == ID)
                .Include(ur => ur.User)
                .Include(ur => ur.Role)
                .SingleOrDefaultAsync(ur => ur.ID == ID);
        }
        public async Task<UserRole?> PatchUserRoleByIDAsync(int ID)
        {
            return await _context.UserRole
                .SingleOrDefaultAsync(ur => ur.ID == ID);
        }
        public IQueryable<UserRole> PaginatedUserRoles(int? ID)
        {
            if (ID.HasValue)
            {
                var query = _context.UserRole
                    .AsNoTracking()
                    .Where(ur => ur.UserID == ID || ur.RoleID == ID)
                    .Include(ur => ur.User)
                    .Include(ur => ur.Role)
                    .OrderByDescending(ur => ur.ID)
                    .AsQueryable();

                return query;
            }
            else
            {
                var query = _context.UserRole
                    .AsNoTracking()
                    .Include(ur => ur.User)
                    .Include(ur => ur.Role)
                    .OrderByDescending(ur => ur.ID)
                    .AsQueryable();

                return query;
            }
        }
        public async Task<List<UserRole>> ListedUserRoles(int? ID)
        {
            if (ID.HasValue)
            {
                return await _context.UserRole
                    .AsNoTracking()
                    .Where(ur => ur.UserID == ID || ur.RoleID == ID)
                    .Include(ur => ur.User)
                    .Include(ur => ur.Role)
                    .OrderByDescending(ur => ur.ID)
                    .ToListAsync();
            }
            else
            {
                return await _context.UserRole
                    .AsNoTracking()
                    .Include(ur => ur.User)
                    .Include(ur => ur.Role)
                    .OrderByDescending(ur => ur.ID)
                    .ToListAsync();
            }
        }
    }
}