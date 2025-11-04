using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API.Controllers
{
    public class PalletPositionQuery
    {
        private readonly DB _context;
        public PalletPositionQuery(DB context)
        {
            _context = context;
        }
        public async Task<PalletPosition?> GetPalletPositionByIDAsync(int ID)
        {
            if (!await _context.PalletPosition.AnyAsync(pp => pp.ID == ID))
            {
                throw new Exception($"Pallet Position ID {ID} not found");
            }
            else
            {
                return await _context.PalletPosition
                    .AsNoTracking()
                    .Include(pp => pp.ColdStorage)
                    .SingleOrDefaultAsync(pp => pp.ID == ID);
            }
        }
        public async Task<PalletPosition?> PatchPalletPositionByIDAsync(int ID)
        {
            if (!await _context.PalletPosition.AnyAsync(pp => pp.ID == ID))
            {
                throw new Exception($"Pallet Position ID {ID} not found");
            }
            else
            {
                return await _context.PalletPosition
                   .Include(pp => pp.ColdStorage)
                   .SingleOrDefaultAsync(pp => pp.ID == ID);
            }
        }
    }
}