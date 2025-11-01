using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API.Controllers
{
    public class CompanyQuery
    {
        private readonly DB _db;
        public CompanyQuery(DB db)
        {
            _db = db;
        }
        public async Task<Company?> GetCompanyByIDAsync(int ID)
        {
            if (!await _db.Company.AnyAsync(c => c.ID == ID))
            {
                throw new Exception($"Company ID {ID} not found");
            }
            else
            {
                return await _db.Company
                .AsNoTracking()
                .Include(c => c.Representative)
                .SingleOrDefaultAsync(c => c.ID == ID);
            }
        }
        public async Task<Company?> PatchCompanyByIDAsync(int ID)
        {
            if (!await _db.Company.AnyAsync(c => c.ID == ID))
            {
                throw new Exception($"Company ID {ID} not found");
            }
            else
            {
                return await _db.Company
                .SingleOrDefaultAsync(c => c.ID == ID);
            }
        }
    }
}