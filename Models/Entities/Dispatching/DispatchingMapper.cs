using AutoMapper;

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
    }
}