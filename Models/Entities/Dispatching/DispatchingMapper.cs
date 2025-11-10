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
            CreateMap<Dispatching, DispatchingOnlyResponse>()
                .ForMember(d => d.CreatorFullName, o => o.MapFrom(s => $"{s.Creator.FirstName} {s.Creator.LastName}"))
                .ForMember(d => d.ApproverFullName, o => o.MapFrom(s => $"{s.Approver.FirstName} {s.Approver.LastName}"));
            CreateMap<Dispatching, DispatchingWithDispatchingPlacementResponse>()
                .ForMember(d => d.CreatorFullName, o => o.MapFrom(s => $"{s.Creator.FirstName} {s.Creator.LastName}"))
                .ForMember(d => d.ApproverFullName, o => o.MapFrom(s => $"{s.Approver.FirstName} {s.Approver.LastName}"))
                .ForMember(d => d.DispatchingPlacement, o => o.MapFrom(s => s.DispatchingPlacement));
        }
        public static class ManualDispatchingMapper
        {
            public static Dispatching ManualDispatchingMapping(CreateDispatchingRequest request, ClaimsPrincipal user)
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
            public static DispatchingPlacement ManualDispatchingPlacementMapping(int dispatchingID, CreateDispatchingPlacementRequest request)
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
        }
    }
}