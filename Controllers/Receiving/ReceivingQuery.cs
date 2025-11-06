using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API.Controllers
{
    public class ReceivingQuery
    {
        private readonly DB _context;
        public ReceivingQuery(DB context)
        {
            _context = context;
        }
        public async Task<Receiving?> GetReceivingByIDAsync(int ID)
        {
            if (!await _context.Receiving.AnyAsync(r => r.ID == ID))
            {
                throw new Exception($"Receiving ID {ID} not found");
            }
            else
            {
                return await _context.Receiving
                    .AsNoTracking()
                    .Include(r => r.Creator)
                    .Include(r => r.Approver)
                    .Include(r => r.ReceivingDetail!)
                    .ThenInclude(rd => rd.Creator)
                    .ThenInclude(c => c.BusinessUnit)
                    .Include(r => r.ReceivingDetail!)
                    .ThenInclude(rd => rd.Creator)
                    .ThenInclude(c => c.Position)
                    .SingleOrDefaultAsync(r => r.ID == ID);
            }
        }
        public async Task<Receiving?> PatchReceivingByIDAsync(int ID)
        {
            if (!await _context.Receiving.AnyAsync(r => r.ID == ID))
            {
                throw new Exception($"Receiving ID {ID} not found");
            }
            else
            {
                return await _context.Receiving
                    .Include(r => r.ReceivingDetail)
                    .SingleOrDefaultAsync(r => r.ID == ID);
            }
        }
    }
}