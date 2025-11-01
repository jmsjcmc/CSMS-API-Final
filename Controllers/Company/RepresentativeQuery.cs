using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API.Controllers
{
    public class RepresentativeQuery
    {
        private readonly DB _db;
        public RepresentativeQuery(DB db)
        {
            _db = db;
        }
        public async Task<Representative?> GetRepresentativeByIDAsync(int ID)
        {
            if (!await _db.Representative.AnyAsync(r => r.ID == ID))
            {
                throw new Exception($"Representative ID {ID} not found");
            }
            else
            {
                return await _db.Representative
                .AsNoTracking()
                .Include(r => r.Company)
                .SingleOrDefaultAsync(r => r.ID == ID);
            }
        }
        public async Task<Representative?> PatchRepresentativeByIDAsync(int ID)
        {
            if (!await _db.Representative.AnyAsync(r => r.ID == ID))
            {
                throw new Exception($"Representative ID {ID} not found");
            }
            else
            {
                return await _db.Representative
                .SingleOrDefaultAsync(r => r.ID == ID);
            }
        }
    }
}