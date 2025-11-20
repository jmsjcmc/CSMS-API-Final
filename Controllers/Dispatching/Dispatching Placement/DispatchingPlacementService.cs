using AutoMapper;
using CSMS_API.Models;
using CSMS_API.Utils;
using System.Security.Claims;

namespace CSMS_API.Controllers
{
    public interface DispatchingPlacementInterface
    {
        Task<DispatchingPlacementOnlyResponse> ApproveDispatchingPlacementByIDAsync(int ID, ClaimsPrincipal user);
    }
    public class DispatchingPlacementService : DispatchingPlacementInterface
    {
        private readonly DB _context;
        private readonly IMapper _mapper;
        private readonly DispatchingPlacementQuery _dispatchingPlacementQuery;
        public DispatchingPlacementService(DB context, IMapper mapper, DispatchingPlacementQuery dispatchingPlacementQuery)
        {
            _context = context;
            _mapper = mapper;
            _dispatchingPlacementQuery = dispatchingPlacementQuery;
        }
        public async Task<DispatchingPlacementOnlyResponse> ApproveDispatchingPlacementByIDAsync(int ID, ClaimsPrincipal user)
        {
            var dispatchingPlacement = await _dispatchingPlacementQuery.PatchDispatchingPlacementByIDAsync(ID);
            dispatchingPlacement.ApproverID = AuthenticationHelper.GetUserIDAsync(user);
            dispatchingPlacement.ApprovedOn = PresentDateTimeFetcher.FetchPresentDateTime();
            dispatchingPlacement.ApprovalStatus = ApprovalStatus.Approved;

            await _context.SaveChangesAsync();

            var dispatchingPlacementLog = new DispatchingPlacementLog
            {
                DispatchingPlacementID = dispatchingPlacement.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.DispatchingPlacementLog.AddAsync(dispatchingPlacementLog);
            await _context.SaveChangesAsync();

            return _mapper.Map<DispatchingPlacementOnlyResponse>(dispatchingPlacement);
        }
    }
}