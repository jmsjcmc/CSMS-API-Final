using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API.Controllers
{
    public class ReceivingDetailQuery
    {
        private readonly DB _context;
        public ReceivingDetailQuery(DB context)
        {
            _context = context;
        }
        public async Task<ReceivingDetail?> GetReceivingDetailByIDAsync(int ID)
        {
            if (!await _context.ReceivingDetail.AnyAsync(rd => rd.ID == ID))
            {
                throw new Exception($"Receiving Detail ID {ID} not found");
            }
            else
            {
                return await _context.ReceivingDetail
                    .AsNoTracking()
                    .Include(rd => rd.Receiving)
                    .Include(rd => rd.Product)
                    .SingleOrDefaultAsync(rd => rd.ID == ID);
            }
        }
        public async Task<ReceivingDetail?> PatchReceivingDetailByIDAsync(int ID)
        {
            if (!await _context.ReceivingDetail.AnyAsync(rd => rd.ID == ID))
            {
                throw new Exception($"Receiving Detail ID {ID} not found");
            }
            else
            {
                return await _context.ReceivingDetail
                    .SingleOrDefaultAsync(rd => rd.ID == ID);
            }
        }
    }
}