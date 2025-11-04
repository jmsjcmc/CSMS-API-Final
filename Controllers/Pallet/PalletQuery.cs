using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API.Controllers
{
    public class PalletQuery
    {
        private readonly DB _context;
        public PalletQuery(DB context)
        {
            _context = context;
        }
        public async Task<Pallet?> GetPalletByIDAsync(int ID)
        {
            if (!await _context.Pallet.AnyAsync(p => p.ID == ID))
            {
                throw new Exception($"Pallet ID {ID} not found");
            }
            else
            {
                return await _context.Pallet
                    .AsNoTracking()
                    .SingleOrDefaultAsync(p => p.ID == ID);
            }
        }
        public async Task<Pallet?> PatchPalletByIDAsync(int ID)
        {
            if (!await _context.Pallet.AnyAsync(p => p.ID == ID))
            {
                throw new Exception($"Pallet ID {ID} not found");
            }
            else
            {
                return await _context.Pallet
                    .SingleOrDefaultAsync(p => p.ID == ID);
            }
        }
    }
}