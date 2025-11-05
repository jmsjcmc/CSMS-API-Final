using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API.Controllers
{
    public class PalletPositionQuery
    {
        private readonly DB _context;
        public PalletPositionQuery(DB context)
        {
            _context = context;
        }
        public async Task<PalletPosition?> GetPalletPositionByIDAsync(int ID)
        {
            if (!await _context.PalletPosition.AnyAsync(pp => pp.ID == ID))
            {
                throw new Exception($"Pallet Position ID {ID} not found");
            }
            else
            {
                return await _context.PalletPosition
                    .AsNoTracking()
                    .Include(pp => pp.ColdStorage)
                    .SingleOrDefaultAsync(pp => pp.ID == ID);
            }
        }
        public async Task<PalletPosition?> PatchPalletPositionByIDAsync(int ID)
        {
            if (!await _context.PalletPosition.AnyAsync(pp => pp.ID == ID))
            {
                throw new Exception($"Pallet Position ID {ID} not found");
            }
            else
            {
                return await _context.PalletPosition
                   .Include(pp => pp.ColdStorage)
                   .SingleOrDefaultAsync(pp => pp.ID == ID);
            }
        }
        public IQueryable<PalletPosition> PaginatedPalletPositions(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var query = _context.PalletPosition
                    .AsNoTracking()
                    .Where(pp => pp.Wing.Contains(searchTerm) ||
                    pp.Floor.Contains(searchTerm) ||
                    pp.Column.Contains(searchTerm) ||
                    pp.Side.Contains(searchTerm))
                    .OrderByDescending(pp => pp.ID)
                    .AsQueryable();

                return query;
            }
            else
            {
                var query = _context.PalletPosition
                   .AsNoTracking()
                   .OrderByDescending(pp => pp.ID)
                   .AsQueryable();

                return query;
            }
        }
        public async Task<List<PalletPosition>> ListedPalletPositions(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                return await _context.PalletPosition
                    .AsNoTracking()
                    .Where(pp => pp.Wing.Contains(searchTerm) ||
                    pp.Floor.Contains(searchTerm) ||
                    pp.Column.Contains(searchTerm) ||
                    pp.Side.Contains(searchTerm))
                    .OrderByDescending(pp => pp.ID)
                    .ToListAsync();
            }
            else
            {
                return await _context.PalletPosition
                   .AsNoTracking()
                   .OrderByDescending(pp => pp.ID)
                   .ToListAsync();
            }
        }
    }
}