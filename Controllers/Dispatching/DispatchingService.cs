using AutoMapper;
using CSMS_API.Models;
using CSMS_API.Utils;
using System.Security.Claims;

namespace CSMS_API.Controllers
{
    public interface DispatchingInterface
    {
        Task<DispatchingWithDispatchingPlacementResponse> CreateDispatchingAsync(CreateDispatchingRequest request, ClaimsPrincipal user);
        Task<DispatchingWithDispatchingPlacementResponse> UpdateDispatchingByIDAsync(int ID, UpdateDispatchingRequest request, ClaimsPrincipal user);
        Task<DispatchingWithDispatchingPlacementResponse> ApproveDispatchingByIDAsync(int ID, ClaimsPrincipal user);
        Task<DispatchingWithDispatchingPlacementResponse> DeleteDispatchingByIDAsync(int ID);
        Task<DispatchingWithDispatchingPlacementResponse> GetDispatchingByIDAsync(int ID);
    }
    public class DispatchingService : DispatchingInterface
    {
        private readonly DB _context;
        private readonly IMapper _mapper;
        private readonly DispatchingQuery _dispatchingQuery;
        public DispatchingService(DB context, IMapper mapper, DispatchingQuery dispatchingQuery)
        {
            _context = context;
            _mapper = mapper;
            _dispatchingQuery = dispatchingQuery;
        }
        public async Task<DispatchingWithDispatchingPlacementResponse> CreateDispatchingAsync(CreateDispatchingRequest request, ClaimsPrincipal user)
        {
            var dispatching = _mapper.Map<Dispatching>(request);
            dispatching.CreatorID = AuthenticationHelper.GetUserIDAsync(user);
            dispatching.CreatedOn = PresentDateTimeFetcher.FetchPresentDateTime();
            dispatching.RecordStatus = RecordStatus.Active;
            dispatching.ApprovalStatus = ApprovalStatus.Pending;
            foreach (var placement in dispatching.DispatchingPlacement)
            {
                placement.CreatorID = AuthenticationHelper.GetUserIDAsync(user);
                placement.CreatedOn = PresentDateTimeFetcher.FetchPresentDateTime();
                placement.RecordStatus = RecordStatus.Active;
                placement.ApprovalStatus = ApprovalStatus.Pending;
            }

            await _context.Dispatching.AddAsync(dispatching);
            await _context.SaveChangesAsync();

            return _mapper.Map<DispatchingWithDispatchingPlacementResponse>(dispatching);
        }
        public async Task<DispatchingWithDispatchingPlacementResponse> UpdateDispatchingByIDAsync(int ID, UpdateDispatchingRequest request, ClaimsPrincipal user)
        {
            var dispatching = await _dispatchingQuery.PatchDispatchingByIDAsync(ID);
            _mapper.Map(request, dispatching);

            await _context.SaveChangesAsync();

            var dispatchingLog = new DispatchingLog
            {
                DispatchingID = dispatching.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.DispatchingLog.AddAsync(dispatchingLog);
            await _context.SaveChangesAsync();

            return _mapper.Map<DispatchingWithDispatchingPlacementResponse>(dispatching);
        }
        public async Task<DispatchingWithDispatchingPlacementResponse> ApproveDispatchingByIDAsync(int ID, ClaimsPrincipal user)
        {
            var dispatching = await _dispatchingQuery.PatchDispatchingByIDAsync(ID);
            dispatching.ApprovalStatus = ApprovalStatus.Approved;

            await _context.SaveChangesAsync();

            var dispatchingLog = new DispatchingLog
            {
                DispatchingID = dispatching.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.DispatchingLog.AddAsync(dispatchingLog);
            await _context.SaveChangesAsync();

            return _mapper.Map<DispatchingWithDispatchingPlacementResponse>(dispatching);
        }
        public async Task<DispatchingWithDispatchingPlacementResponse> DeleteDispatchingByIDAsync(int ID)
        {
            var dispatching = await _dispatchingQuery.PatchDispatchingByIDAsync(ID);

            _context.Dispatching.Remove(dispatching);
            await _context.SaveChangesAsync();

            return _mapper.Map<DispatchingWithDispatchingPlacementResponse>(dispatching);
        }
        public async Task<DispatchingWithDispatchingPlacementResponse> GetDispatchingByIDAsync(int ID)
        {
            var dispatching = await _dispatchingQuery.GetDispatchingByIDAsync(ID);

            return _mapper.Map<DispatchingWithDispatchingPlacementResponse>(dispatching);
        }
    }
}