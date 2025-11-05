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
        public IQueryable<BusinessUnit> PaginatedBusinessUnits (string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var query = _context.BusinessUnit
                   .AsNoTracking()
                   .Where(bu => bu.Name.Contains(searchTerm) ||
                    bu.Location.Contains(searchTerm))
                   .OrderByDescending(bu => bu.ID)
                   .AsQueryable();

                return query;
            } else
            {
                var query = _context.BusinessUnit
                    .AsNoTracking()
                    .OrderByDescending(bu => bu.ID)
                    .AsQueryable();

                return query;
            }
        }
        public async Task<List<BusinessUnit>> ListedBusinessUnitsAsync(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                return await _context.BusinessUnit
                    .AsNoTracking()
                    .Where(bu => bu.Name.Contains(searchTerm) ||
                    bu.Location.Contains(searchTerm))
                    .OrderByDescending(bu => bu.ID)
                    .ToListAsync();
            } else
            {
                return await _context.BusinessUnit
                    .AsNoTracking()
                    .OrderByDescending(bu => bu.ID)
                    .ToListAsync();
            }
        }
    }
}