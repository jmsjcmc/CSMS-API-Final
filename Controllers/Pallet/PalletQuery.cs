using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API.Controllers
{
    public class PalletQuery : IPalletQueries
    {
        private readonly DB _context;
        public PalletQuery(DB context)
        {
            _context = context;
        }
        public async Task<Pallet?> PatchPalletByIDAsync(int ID)
        {
            return await _context.Pallet
                .SingleOrDefaultAsync(P => P.ID == ID);
        }
        public async Task<PalletOnlyResponse?> PalletOnlyResponseByIDAsync(int ID)
        {
            return await _context.Pallet
                .AsNoTracking()
                .Where(P => P.ID == ID)
                .Select(P => new PalletOnlyResponse
                {
                    ID = P.ID,
                    Type = P.Type,
                    Number = P.Number,
                    CreatedOn = P.CreatedOn,
                    RecordStatus = P.RecordStatus,
                    PalletOccupationStatus = P.PalletOccupationStatus
                }).SingleOrDefaultAsync();
        }
        public IQueryable<PalletOnlyResponse> PalletOnlyResponseAsync(string? searchTerm, RecordStatus? recordStatus, PalletOccupationStatus? palletOccupationStatus)
        {
            var query = _context.Pallet
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(P => P.Type.Contains(searchTerm));
            }
            if (recordStatus.HasValue)
            {
                query = query.Where(P => P.RecordStatus == recordStatus.Value);
            }
            if (palletOccupationStatus.HasValue)
            {
                query = query.Where(P => P.PalletOccupationStatus == palletOccupationStatus.Value);
            }

            return query
                .OrderByDescending(P => P.ID)
                .Select(P => new PalletOnlyResponse
                {
                    ID = P.ID,
                    Type = P.Type,
                    Number = P.Number,
                    CreatedOn = P.CreatedOn,
                    RecordStatus = P.RecordStatus,
                    PalletOccupationStatus = P.PalletOccupationStatus
                });
        }
    }
}