using AutoMapper;
using CSMS_API.Models;
using CSMS_API.Utils;
using System.Security.Claims;

namespace CSMS_API.Controllers
{
    public interface PalletPositionInterface
    {
        Task<PalletPositionOnlyResponse> CreatePalletPositionAsync(CreatePalletPositionRequest request, ClaimsPrincipal user);
        Task<PalletPositionWithColdStorageResponse> AddColdStorageToPalletPositionByIDAsync(int palletPositionID, int coldStorageID, ClaimsPrincipal user);
        Task<PalletPositionOnlyResponse> UpdatePalletPositionByIDAsync(int ID, UpdatePalletPositionRequest request, ClaimsPrincipal user);
        Task<PalletPositionOnlyResponse> DeletePalletPositionByIDAsync(int ID);
        Task<PalletPositionWithColdStorageResponse> GetPalletPositionByIDAsync(int ID);
    }
    public class PalletPositionService : PalletPositionInterface
    {
        private readonly DB _context;
        private readonly IMapper _mapper;
        private readonly PalletPositionQuery _palletPositionQuery;
        public PalletPositionService(DB context, IMapper mapper, PalletPositionQuery palletPositionQuery)
        {
            _context = context;
            _mapper = mapper;
            _palletPositionQuery = palletPositionQuery;
        }
        public async Task<PalletPositionOnlyResponse> CreatePalletPositionAsync(CreatePalletPositionRequest request, ClaimsPrincipal user)
        {
            var palletPosition = _mapper.Map<PalletPosition>(request);
            palletPosition.CreatorID = AuthenticationHelper.GetUserIDAsync(user);
            palletPosition.CreatedOn = PresentDateTimeFetcher.FetchPresentDateTime();
            palletPosition.RecordStatus = RecordStatus.Active;

            await _context.PalletPosition.AddAsync(palletPosition);
            await _context.SaveChangesAsync();

            return _mapper.Map<PalletPositionOnlyResponse>(palletPosition);
        }
        public async Task<PalletPositionWithColdStorageResponse> AddColdStorageToPalletPositionByIDAsync(int palletPositionID, int coldStorageID, ClaimsPrincipal user)
        {
            var palletPosition = await _palletPositionQuery.PatchPalletPositionByIDAsync(palletPositionID);

            palletPosition.ColdStorageID = coldStorageID;

            await _context.SaveChangesAsync();

            var palletPositionLog = new PalletPositionLog
            {
                PalletPositionID = palletPosition.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.PalletPositionLog.AddAsync(palletPositionLog);
            await _context.SaveChangesAsync();

            return _mapper.Map<PalletPositionWithColdStorageResponse>(palletPosition);
        }
        public async Task<PalletPositionOnlyResponse> UpdatePalletPositionByIDAsync(int ID, UpdatePalletPositionRequest request, ClaimsPrincipal user)
        {
            var palletPosition = await _palletPositionQuery.PatchPalletPositionByIDAsync(ID);

            _mapper.Map(request, palletPosition);

            await _context.SaveChangesAsync();

            var palletPositionLog = new PalletPositionLog
            {
                PalletPositionID = palletPosition.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.PalletPositionLog.AddAsync(palletPositionLog);
            await _context.SaveChangesAsync();

            return _mapper.Map<PalletPositionOnlyResponse>(palletPosition);
        }
        public async Task<PalletPositionOnlyResponse> DeletePalletPositionByIDAsync(int ID)
        {
            var palletPosition = await _palletPositionQuery.PatchPalletPositionByIDAsync(ID);

            _context.PalletPosition.Remove(palletPosition);
            await _context.SaveChangesAsync();

            return _mapper.Map<PalletPositionOnlyResponse>(palletPosition);
        }
        public async Task<PalletPositionWithColdStorageResponse> GetPalletPositionByIDAsync(int ID)
        {
            var palletPosition = await _palletPositionQuery.GetPalletPositionByIDAsync(ID);
            return _mapper.Map<PalletPositionWithColdStorageResponse>(palletPosition);
        }
    }
}