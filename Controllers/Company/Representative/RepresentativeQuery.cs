using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API.Controllers
{
    public class RepresentativeQuery
    {
        private readonly DB _context;
        public RepresentativeQuery(DB context)
        {
            _context = context;
        }
        public async Task<Representative?> GetRepresentativeByIDAsync(int ID)
        {
            if (!await _context.Representative.AnyAsync(r => r.ID == ID))
            {
                throw new Exception($"Representative ID {ID} not found");
            }
            else
            {
                return await _context.Representative
                .AsNoTracking()
                .Include(r => r.Company)
                .SingleOrDefaultAsync(r => r.ID == ID);
            }
        }
        public async Task<Representative?> PatchRepresentativeByIDAsync(int ID)
        {
            if (!await _context.Representative.AnyAsync(r => r.ID == ID))
            {
                throw new Exception($"Representative ID {ID} not found");
            }
            else
            {
                return await _context.Representative
                .SingleOrDefaultAsync(r => r.ID == ID);
            }
        }
        public IQueryable<Representative> PaginatedRepresentatives(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var query = _context.Representative
                    .AsNoTracking()
                    .Where(r => r.FirstName.Contains(searchTerm) ||
                    r.LastName.Contains(searchTerm) ||
                    r.Position.Contains(searchTerm))
                    .OrderByDescending(r => r.ID)
                    .AsQueryable();

                return query;
            }
            else
            {
                var query = _context.Representative
                    .AsNoTracking()
                    .OrderByDescending(r => r.ID)
                    .AsQueryable();

                return query;
            }
        }
        public async Task<List<Representative>> ListedRepresentatives(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                return await _context.Representative
                    .AsNoTracking()
                    .Where(r => r.FirstName.Contains(searchTerm) ||
                    r.LastName.Contains(searchTerm) ||
                    r.Position.Contains(searchTerm))
                    .OrderByDescending(r => r.ID)
                    .ToListAsync();
            } else
            {
                return await _context.Representative
                    .AsNoTracking()
                    .OrderByDescending(r => r.ID)
                    .ToListAsync();
            }
        }
    }
}