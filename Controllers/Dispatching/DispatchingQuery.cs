using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API.Controllers
{
    public class DispatchingQuery
    {
        private readonly DB _context;
        public DispatchingQuery(DB context)
        {
            _context = context;
        }
        public async Task<Dispatching?> GetDispatchingByIDAsync(int ID)
        {
            return await _context.Dispatching
            .AsNoTracking()
            .Include(d => d.DispatchingPlacement)
            .SingleOrDefaultAsync(d => d.ID == ID);
        }
        public async Task<Dispatching?> PatchDispatchingByIDAsync(int ID)
        {
            return await _context.Dispatching
            .SingleOrDefaultAsync(d => d.ID == ID);
        }
        public IQueryable<Dispatching> PaginatedDispatching(string? searchTerm)
        {
             if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var query = _context.Dispatching
                .AsNoTracking()
                .Where(d => d.DocumentNo.Contains(searchTerm))
                .Include(d => d.DispatchingPlacement)
                .OrderByDescending(d => d.ID)
                .AsQueryable();

                return query;
            } else
            {
                 var query = _context.Dispatching
                .AsNoTracking()
                .Include(d => d.DispatchingPlacement)
                .OrderByDescending(d => d.ID)
                .AsQueryable();

                return query;
            }
        }
        public async Task<List<Dispatching>> ListedDispatchings(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                return await _context.Dispatching
                .AsNoTracking()
                .Where(d => d.DocumentNo.Contains(searchTerm))
                .Include(d => d.DispatchingPlacement)
                .OrderByDescending(d => d.ID)
                .ToListAsync();
            } else
            {
                return await _context.Dispatching
                .AsNoTracking()
                .Include(d => d.DispatchingPlacement)
                .OrderByDescending(d => d.ID)
                .ToListAsync();
            }
        }
    }
}