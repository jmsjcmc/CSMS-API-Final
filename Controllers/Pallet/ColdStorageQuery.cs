using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API.Controllers
{
    public class ColdStorageQuery
    {
        private readonly DB _context;
        public ColdStorageQuery(DB context)
        {
            _context = context;
        }
        public async Task<ColdStorage?> GetColdStorageByIDAsync(int ID)
        {
            if (!await _context.ColdStorage.AnyAsync(cs => cs.ID == ID))
            {
                throw new Exception($"Cold Storage ID {ID} not found");
            }
            else
            {
                return await _context.ColdStorage
                    .AsNoTracking()
                    .SingleOrDefaultAsync(cs => cs.ID == ID);
            }
        }
        public async Task<ColdStorage?> PatchColdStorageByIDAsync(int ID)
        {
            if (!await _context.ColdStorage.AnyAsync(cs => cs.ID == ID))
            {
                throw new Exception($"Cold Storage ID {ID} not found");
            }
            else
            {
                return await _context.ColdStorage
                   .SingleOrDefaultAsync(cs => cs.ID == ID);
            }
        }
    }
}