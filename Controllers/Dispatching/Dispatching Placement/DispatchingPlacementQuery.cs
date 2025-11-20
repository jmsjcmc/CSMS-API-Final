using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API.Controllers
{
    public class DispatchingPlacementQuery
    {
        private readonly DB _context;
        public DispatchingPlacementQuery(DB context)
        {
            _context = context;
        }
        public async Task<DispatchingPlacement?> GetDispatchingPlacementByIDAsync(int ID)
        {
            return await _context.DispatchingPlacement
                .AsNoTracking()
                .Include(dp => dp.ReceivingPlacement)
                .Include(dp => dp.Dispatching)
                .Include(dp => dp.Pallet)
                .Include(dp => dp.PalletPosition)
                .SingleOrDefaultAsync(dp => dp.ID == ID);
        }
        public async Task<DispatchingPlacement?> PatchDispatchingPlacementByIDAsync(int ID)
        {
            return await _context.DispatchingPlacement
                .SingleOrDefaultAsync(dp => dp.ID == ID);
        }
    }
}