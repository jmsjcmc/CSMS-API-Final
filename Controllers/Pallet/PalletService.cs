using AutoMapper;
using CSMS_API.Models;
using CSMS_API.Utils;
using System.Security.Claims;

namespace CSMS_API.Controllers
{
    public interface PalletInterface
    {
        Task<PalletOnlyResponse> CreatePalletAsync(CreatePalletRequest request, ClaimsPrincipal user);
        Task<PalletOnlyResponse> UpdatePalletByIDAsync(int ID, UpdatePalletRequest request, ClaimsPrincipal user);
        Task<PalletOnlyResponse> DeletePalletByIDAsync(int ID);
        Task<PalletOnlyResponse> GetPalletByIDAsync(int ID);
    }
    public class PalletService : PalletInterface
    {
        private readonly DB _context;
        private readonly IMapper _mapper;
        private readonly PalletQuery _palletQuery;
        public PalletService(DB context, IMapper mapper, PalletQuery palletQuery)
        {
            _context = context;
            _mapper = mapper;
            _palletQuery = palletQuery;
        }
        public async Task<PalletOnlyResponse> CreatePalletAsync(CreatePalletRequest request, ClaimsPrincipal user)
        {
            var pallet = _mapper.Map<Pallet>(request);

            await _context.Pallet.AddAsync(pallet);
            await _context.SaveChangesAsync();

            return _mapper.Map<PalletOnlyResponse>(pallet);
        }
        public async Task<PalletOnlyResponse> UpdatePalletByIDAsync(int ID, UpdatePalletRequest request, ClaimsPrincipal user)
        {
            var pallet = await _palletQuery.PatchPalletByIDAsync(ID);

            _mapper.Map(request, pallet);

            await _context.SaveChangesAsync();

            var palletLog = new PalletLog
            {
                PalletID = pallet.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.PalletLog.AddAsync(palletLog);
            await _context.SaveChangesAsync();

            return _mapper.Map<PalletOnlyResponse>(pallet);
        }
        public async Task<PalletOnlyResponse> DeletePalletByIDAsync(int ID)
        {
            var pallet = await _palletQuery.PatchPalletByIDAsync(ID);

            _context.Pallet.Remove(pallet);
            await _context.SaveChangesAsync();

            return _mapper.Map<PalletOnlyResponse>(pallet);
        }
        public async Task<PalletOnlyResponse> GetPalletByIDAsync(int ID)
        {
            var pallet = await _palletQuery.GetPalletByIDAsync(ID);
            return _mapper.Map<PalletOnlyResponse>(pallet);
        }
    }
}