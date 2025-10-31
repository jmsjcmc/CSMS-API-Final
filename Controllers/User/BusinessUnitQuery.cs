using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API.Controllers
{
    public class BusinessUnitQuery
    {
        private readonly DB _context;
        public BusinessUnitQuery(DB context)
        {
            _context = context;
        }
        public async Task<BusinessUnit?> GetBusinessUnitByIDAsync(int ID)
        {
            if (!await _context.BusinessUnit.AnyAsync(bu => bu.ID == ID))
            {
                throw new Exception($"Business Unit ID {ID} not found");
            }
            else
            {
                return await _context.BusinessUnit
                    .AsNoTracking()
                    .SingleOrDefaultAsync(bu => bu.ID == ID);
            }
        }
        public async Task<BusinessUnit?> PatchBusinessUnitByIDAsync(int ID)
        {
            if (!await _context.BusinessUnit.AnyAsync(bu => bu.ID == ID))
            {
                throw new Exception($"Business Unit ID {ID} not found");
            }
            else
            {
                return await _context.BusinessUnit
                    .SingleOrDefaultAsync(bu => bu.ID == ID);
            }
        }
        
    }
}