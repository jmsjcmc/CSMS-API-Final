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
    }
}
