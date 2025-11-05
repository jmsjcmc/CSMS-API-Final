using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CSMS_API.Controllers
{
    public class PositionQuery
    {
        private readonly DB _context;
        public PositionQuery(DB context)
        {
            _context = context;
        }
        public async Task<Position?> GetPositionByIDAsync(int ID)
        {
            if (!await _context.Position.AnyAsync(p => p.ID == ID))
            {
                throw new Exception($"Position ID {ID} not found");
            }
            else
            {
                return await _context.Position
                .AsNoTracking()
                .Include(p => p.Department)
                .SingleOrDefaultAsync(p => p.ID == ID);
            }
        }
        public async Task<Position?> PatchPositionByIDAsync(int ID)
        {
            if (!await _context.Position.AnyAsync(p => p.ID == ID))
            {
                throw new Exception($"Position ID {ID} not found");
            }
            else
            {
                return await _context.Position
                .SingleOrDefaultAsync(p => p.ID == ID);
            }
        }
        public IQueryable<Position> PaginatedPositions(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var query = _context.Position
                    .AsNoTracking()
                    .Where(pp => pp.Name.Contains(searchTerm))
                    .OrderByDescending(pp => pp.ID)
                    .AsQueryable();

                return query;
            } else
            {
                var query = _context.Position
                   .AsNoTracking()
                   .OrderByDescending(pp => pp.ID)
                   .AsQueryable();

                return query;
            }
        }
        public IQueryable<Position?> PaginatedPositionsWithDepartment(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var query = _context.Position
                    .AsNoTracking()
                    .Where(pp => pp.Name.Contains(searchTerm))
                    .Include(p => p.Department)
                    .OrderByDescending(pp => pp.ID)
                    .AsQueryable();

                return query;
            }
            else
            {
                var query = _context.Position
                   .AsNoTracking()
                   .Include(p => p.Department)
                   .OrderByDescending(pp => pp.ID)
                   .AsQueryable();

                return query;
            }
        }
        public async Task<List<Position>> ListedPositions(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                return await _context.Position
                    .AsNoTracking()
                    .Where(pp => pp.Name.Contains(searchTerm))
                    .OrderByDescending(pp => pp.ID)
                    .ToListAsync();
            }
            else
            {
                return await _context.Position
                    .AsNoTracking()
                    .OrderByDescending(pp => pp.ID)
                    .ToListAsync();
            }
        }
        public async Task<List<Position>> ListedPositionsWithDepartment(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                return await _context.Position
                    .AsNoTracking()
                    .Where(pp => pp.Name.Contains(searchTerm))
                    .Include(pp => pp.Department)
                    .OrderByDescending(pp => pp.ID)
                    .ToListAsync();
            }
            else
            {
                return await _context.Position
                    .AsNoTracking()
                    .Include(pp => pp.Department)
                    .OrderByDescending(pp => pp.ID)
                    .ToListAsync();
            }
        }
    }
}