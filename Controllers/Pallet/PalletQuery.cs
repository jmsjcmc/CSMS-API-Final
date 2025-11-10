using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API.Controllers
{
    public class PalletQuery
    {
        private readonly DB _context;
        public PalletQuery(DB context)
        {
            _context = context;
        }
        public async Task<Pallet?> GetPalletByIDAsync(int ID)
        {
            if (!await _context.Pallet.AnyAsync(p => p.ID == ID))
            {
                throw new Exception($"Pallet ID {ID} not found");
            }
            else
            {
                return await _context.Pallet
                    .AsNoTracking()
                    .SingleOrDefaultAsync(p => p.ID == ID);
            }
        }
        public async Task<Pallet?> PatchPalletByIDAsync(int ID)
        {
            if (!await _context.Pallet.AnyAsync(p => p.ID == ID))
            {
                throw new Exception($"Pallet ID {ID} not found");
            }
            else
            {
                return await _context.Pallet
                    .SingleOrDefaultAsync(p => p.ID == ID);
            }
        }
        public IQueryable<Pallet> PaginatedPallets(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var query = _context.Pallet
                    .AsNoTracking()
                    .Where(p => p.Type.Contains(searchTerm) ||
                    p.Number.Contains(searchTerm))
                    .OrderByDescending(p => p.ID)
                    .AsQueryable();

                return query;
            }
            else
            {
                var query = _context.Pallet
                    .AsNoTracking()
                    .OrderByDescending(p => p.ID)
                    .AsQueryable();

                return query;
            }
        }
        public async Task<List<Pallet>> ListedPallets(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                return await _context.Pallet
                    .AsNoTracking()
                    .Where(p => p.Type.Contains(searchTerm) ||
                    p.Number.Contains(searchTerm))
                    .OrderByDescending(p => p.ID)
                    .ToListAsync();
            } else
            {
                return await _context.Pallet
                    .AsNoTracking()
                    .OrderByDescending(p => p.ID)
                    .ToListAsync();
            }
        }
        public async Task<List<Pallet>> ListedEmptyPallets(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                return await _context.Pallet
                    .AsNoTracking()
                    .Where(p => p.Type.Contains(searchTerm) ||
                    p.Number.Contains(searchTerm) &&
                    p.PalletOccupationStatus == PalletOccupationStatus.Empty)
                    .OrderByDescending(p => p.ID)
                    .ToListAsync();
            }
            else
            {
                return await _context.Pallet
                    .AsNoTracking()
                    .Where(p => p.PalletOccupationStatus == PalletOccupationStatus.Empty)
                    .OrderByDescending(p => p.ID)
                    .ToListAsync();
            }
        }
    }
}