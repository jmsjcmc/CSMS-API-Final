using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API.Controllers
{
    public class UserQuery
    {
        private readonly DB _context;
        public UserQuery(DB context)
        {
            _context = context;
        }
        public async Task<User?> GetUserByIDAsync(int ID)
        {
            if (!await _context.User.AnyAsync(u => u.ID == ID))
            {
                throw new Exception($"User ID {ID} not found");
            }
            else
            {
                return await _context.User
                    .AsNoTracking()
                    .Include(u => u.BusinessUnit)
                    .Include(u => u.Position)
                    .ThenInclude(p => p.Department)
                    .SingleOrDefaultAsync(u => u.ID == ID);
            }
        }
        public async Task<User?> PatchUserByIDAsync(int ID)
        {
            if (!await _context.User.AnyAsync(u => u.ID == ID))
            {
                throw new Exception($"User ID {ID} not found");
            }
            else
            {
                return await _context.User
                    .SingleOrDefaultAsync(u => u.ID == ID);
            }
        }
        public IQueryable<User?> PaginatedUsers(string searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var query = _context.User
                    .AsNoTracking()
                    .Where(u => u.FirstName.Contains(searchTerm) ||
                    u.LastName.Contains(searchTerm) ||
                    u.Username.Contains(searchTerm))
                    .OrderByDescending(u => u.ID)
                    .AsQueryable();

                return query;
            } else
            {
                var query = _context.User
                    .AsNoTracking()
                    .OrderByDescending(u => u.ID)
                    .AsQueryable();

                return query;
            }
        }
        public IQueryable<User> PaginatedUsersWithBusinessUnitAndPosition(string searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var query = _context.User
                    .AsNoTracking()
                    .Where(u => u.FirstName.Contains(searchTerm) ||
                    u.LastName.Contains(searchTerm) ||
                    u.Username.Contains(searchTerm))
                    .Include(u => u.BusinessUnit)
                    .Include(u => u.Position)
                    .OrderByDescending(u => u.ID)
                    .AsQueryable();

                return query;
            }
            else
            {
                var query = _context.User
                    .AsNoTracking()
                    .Include(u => u.BusinessUnit)
                    .Include(u => u.Position)
                    .OrderByDescending(u => u.ID)
                    .AsQueryable();

                return query;
            }
        }
        public async Task<List<User>> ListedUsers(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                return await _context.User
                    .AsNoTracking()
                    .Where(u => u.FirstName.Contains(searchTerm) ||
                    u.LastName.Contains(searchTerm) ||
                    u.Username.Contains(searchTerm))
                    .OrderByDescending(u => u.ID)
                    .ToListAsync();
            }
            else
            {
                return await _context.User
                    .AsNoTracking()
                    .OrderByDescending(u => u.ID)
                    .ToListAsync();
            }
        }
        public async Task<List<User>> ListedUsersWithBusinessUnitAndPosition(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                return await _context.User
                    .AsNoTracking()
                    .Where(u => u.FirstName.Contains(searchTerm) ||
                    u.LastName.Contains(searchTerm) ||
                    u.Username.Contains(searchTerm))
                    .Include(u => u.BusinessUnit)
                    .Include(u => u.Position)
                    .OrderByDescending(u => u.ID)
                    .ToListAsync();
            }
            else
            {
                return await _context.User
                    .AsNoTracking()
                    .Include(u => u.BusinessUnit)
                    .Include(u => u.Position)
                    .OrderByDescending(u => u.ID)
                    .ToListAsync();
            }
        }
    }
}
