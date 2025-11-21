using AutoMapper;
using CSMS_API.Utils;
using System.Security.Claims;

namespace CSMS_API.Models
{
    public class DispatchingMapper : Profile
    {
        public DispatchingMapper()
        {
            CreateMap<CreateDispatchingRequest, Dispatching>()
                .ForMember(d => d.DispatchingPlacement, o => o.MapFrom(s => s.DispatchingPlacement));
            CreateMap<UpdateDispatchingRequest, Dispatching>()
                .ForMember(d => d.DispatchingPlacement, o => o.MapFrom(s => s.DispatchingPlacement));
            CreateMap<Dispatching, DispatchingWithDispatchingPlacementResponse>()
                .ForMember(d => d.CreatorFullName, o => o.MapFrom(s => $"{s.Creator.FirstName} {s.Creator.LastName}"))
                .ForMember(d => d.ApproverFullName, o => o.MapFrom(s => $"{s.Approver.FirstName} {s.Approver.LastName}"))
                .ForMember(d => d.DispatchingPlacement, o => o.MapFrom(s => s.DispatchingPlacement));
        }
        public static class ManualDispatchingMapper
        {
            public static Dispatching ManualDispatchingRequestMapping(CreateDispatchingRequest request, ClaimsPrincipal user)
            {
                return new Dispatching
                {
                    DocumentNo = request.DocumentNo,
                    DispatchDate = request.DispatchDate,
                    DispatchTimeStart = request.DispatchTimeStart,
                    DispatchTimeEnd = request.DispatchTimeEnd,
                    NMISCertificate = request.NMISCertificate,
                    DispatchPlateNo = request.DispatchPlateNo,
                    SealNo = request.SealNo,
                    OverAllWeight = request.OverAllWeight,
                    CreatorID = AuthenticationHelper.GetUserIDAsync(user),
                    CreatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
                };
            }
            public static DispatchingPlacement ManualDispatchingPlacementRequestMapping(int dispatchingID, CreateDispatchingPlacementRequest request)
            {
                return new DispatchingPlacement
                {
                    DispatchingID = dispatchingID,
                    ReceivingPlacementID = request.ReceivingPlacementID,
                    PalletID = request.PalletID,
                    PalletPositionID = request.PalletPositionID,
                    Quantity = request.Quantity,
                    Weight = request.Weight
                };
            }
            public static DispatchingOnlyResponse ManualDispatchingOnlyResponse(Dispatching dispatching)
            {
                return new DispatchingOnlyResponse
                {
                    ID = dispatching.ID,
                    DocumentNo = dispatching.DocumentNo,
                    DispatchDate = dispatching.DispatchDate,
                    DispatchTimeStart = dispatching.DispatchTimeStart,
                    DispatchTimeEnd = dispatching.DispatchTimeEnd,
                    NMISCertificate = dispatching.NMISCertificate,
                    DispatchPlateNo = dispatching.DispatchPlateNo,
                    SealNo = dispatching.SealNo,
                    OverAllWeight = dispatching.OverAllWeight,
                    Note = dispatching.Note,
                    CreatorFullName = $"{dispatching.Creator.FirstName} {dispatching.Creator.LastName}",
                    CreatedOn = dispatching.CreatedOn,
                    ApproverFullName = $"{dispatching.Approver.FirstName} {dispatching.Approver.LastName}",
                    ApprovedOn = dispatching.ApprovedOn,
                    DeclinedOn = dispatching.DeclinedOn,
                    RecordStatus = dispatching.RecordStatus
                };
            }
            public static List<DispatchingOnlyResponse> ManualDispatchingOnlyListResponse(List<Dispatching> dispatchings)
            {
                return dispatchings
                    .Select(ManualDispatchingOnlyResponse)
                    .ToList();
            }
            public static DispatchingWithDispatchingPlacementResponse ManualDispatchingWithDispatchingPlacementResponse(Dispatching dispatching)
            {
                return new DispatchingWithDispatchingPlacementResponse
                {
                    ID = dispatching.ID,
                    DocumentNo = dispatching.DocumentNo,
                    DispatchDate = dispatching.DispatchDate,
                    DispatchTimeStart = dispatching.DispatchTimeStart,
                    DispatchTimeEnd = dispatching.DispatchTimeEnd,
                    NMISCertificate = dispatching.NMISCertificate,
                    DispatchPlateNo = dispatching.DispatchPlateNo,
                    SealNo = dispatching.SealNo,
                    OverAllWeight = dispatching.OverAllWeight,
                    Note = dispatching.Note,
                    CreatorFullName = $"{dispatching.Creator.FirstName} {dispatching.Creator.LastName}",
                    CreatedOn = dispatching.CreatedOn,
                    ApproverFullName = $"{dispatching.Approver.FirstName} {dispatching.Approver.LastName}",
                    ApprovedOn = dispatching.ApprovedOn,
                    DeclinedOn = dispatching.DeclinedOn,
                    RecordStatus = dispatching.RecordStatus,
                    DispatchingPlacement = dispatching.DispatchingPlacement != null
                    ? ManualDispatchingPlacementMapping.ManualDispatchingPlacementOnlyListResponse(dispatching.DispatchingPlacement.ToList())
                    : null
                };
            }
            public static List<DispatchingWithDispatchingPlacementResponse> ManualDispatchingWithDispatchingPlacementResponse(List<Dispatching> dispatchings)
            {
                return dispatchings
                    .Select(ManualDispatchingWithDispatchingPlacementResponse)
                    .ToList();
            }
        }
    }
}