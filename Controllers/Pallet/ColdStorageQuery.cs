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
        public IQueryable<ColdStorage> PaginatedColdStorages(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var query = _context.ColdStorage
                    .AsNoTracking()
                    .Where(cs => cs.Number.Contains(searchTerm))
                    .OrderByDescending(cs => cs.ID)
                    .AsQueryable();

                return query;
            }
            else
            {
                var query = _context.ColdStorage
                   .AsNoTracking()
                   .OrderByDescending(cs => cs.ID)
                   .AsQueryable();

                return query;
            }
        }
        public async Task<List<ColdStorage>> ListedColdStorages(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                return await _context.ColdStorage
                    .AsNoTracking()
                    .Where(cs => cs.Number.Contains(searchTerm))
                    .OrderByDescending(cs => cs.ID)
                    .ToListAsync();
            }
            else
            {
                return await _context.ColdStorage
                    .AsNoTracking()
                    .OrderByDescending(cs => cs.ID)
                    .ToListAsync();
            }
        }
    }
}