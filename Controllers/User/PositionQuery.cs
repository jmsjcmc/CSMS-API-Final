using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API.Controllers
{
    public class PositionQuery
    {
        private readonly DB _context;
        public PositionQuery(DB context)
        {
            _context = context;
        }
        public async Task<Position?> GetPositionByIDAsync(int ID)
        {
            if (!await _context.Position.AnyAsync(p => p.ID == ID))
            {
                throw new Exception($"Position ID {ID} not found");
            }
            else
            {
                return await _context.Position
                .AsNoTracking()
                .Include(p => p.Department)
                .SingleOrDefaultAsync(p => p.ID == ID);
            }
        }
        public async Task<Position?> PatchPositionByIDAsync(int ID)
        {
            if (!await _context.Position.AnyAsync(p => p.ID == ID))
            {
                throw new Exception($"Position ID {ID} not found");
            }
            else
            {
                return await _context.Position
                .SingleOrDefaultAsync(p => p.ID == ID);
            }
        }
    }
}