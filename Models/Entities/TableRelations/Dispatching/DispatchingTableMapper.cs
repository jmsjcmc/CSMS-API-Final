using AutoMapper;

namespace CSMS_API.Models
{
    public class DispatchingTablerMapper : Profile
    {
        public DispatchingTablerMapper()
        {
            CreateMap<CreateDispatchingPlacementRequest, DispatchingPlacement>();
            CreateMap<UpdateDispatchingPlacementRequest, DispatchingPlacement>();
            CreateMap<DispatchingPlacement, DispatchingOnlyResponse>();
            CreateMap<DispatchingPlacement, DispatchingPlacementWithReceivingPlacementDispatchingPalletAndPalletPositionResponse>()
                .ForMember(d => d.ReceivingPlacementID, o => o.MapFrom(s => s.ReceivingPlacement.ID))
                .ForMember(d => d.ReceivingPlacementQuantity, o => o.MapFrom(s => s.ReceivingPlacement.Quantity))
                .ForMember(d => d.ReceivingPlacementWeight, o => o.MapFrom(s => s.ReceivingPlacement.Weight))
                .ForMember(d => d.TaggingNumber, o => o.MapFrom(s => s.ReceivingPlacement.TaggingNumber))
                .ForMember(d => d.CrateNumber, o => o.MapFrom(s => s.ReceivingPlacement.CrateNumber))
                .ForMember(d => d.DispatchingID, o => o.MapFrom(s => s.Dispatching.ID))
                .ForMember(d => d.DocumentNo, o => o.MapFrom(s => s.Dispatching.DocumentNo))
                .ForMember(d => d.DispatchDate, o => o.MapFrom(s => s.Dispatching.DispatchDate))
                .ForMember(d => d.DispatchTimeStart, o => o.MapFrom(s => s.Dispatching.DispatchTimeStart))
                .ForMember(d => d.DispatchTimeEnd, o => o.MapFrom(s => s.Dispatching.DispatchTimeEnd))
                .ForMember(d => d.NMISCertificate, o => o.MapFrom(s => s.Dispatching.NMISCertificate))
                .ForMember(d => d.DispatchPlateNo, o => o.MapFrom(s => s.Dispatching.DispatchPlateNo))
                .ForMember(d => d.SealNo, o => o.MapFrom(s => s.Dispatching.SealNo))
                .ForMember(d => d.OverAllWeight, o => o.MapFrom(s => s.Dispatching.OverAllWeight))
                .ForMember(d => d.PalletID, o => o.MapFrom(s => s.Pallet.ID))
                .ForMember(d => d.Type, o => o.MapFrom(s => s.Pallet.Type))
                .ForMember(d => d.Number, o => o.MapFrom(s => s.Pallet.Number))
                .ForMember(d => d.PalletPositionID, o => o.MapFrom(s => s.PalletPosition.ID))
                .ForMember(d => d.ColdStorageID, o => o.MapFrom(s => s.PalletPosition.ColdStorage.ID))
                .ForMember(d => d.ColdStorageNumber, o => o.MapFrom(s => s.PalletPosition.ColdStorage.Number))
                .ForMember(d => d.Wing, o => o.MapFrom(s => s.PalletPosition.Wing))
                .ForMember(d => d.Floor, o => o.MapFrom(s => s.PalletPosition.Floor))
                .ForMember(d => d.Column, o => o.MapFrom(s => s.PalletPosition.Column))
                .ForMember(d => d.Side, o => o.MapFrom(s => s.PalletPosition.Side))
                .ForMember(d => d.CreatorFullName, o => o.MapFrom(s => $"{s.Creator.FirstName} {s.Creator.LastName}"))
                .ForMember(d => d.ApproverFullName, o => o.MapFrom(s => $"{s.Approver.FirstName} {s.Approver.LastName}"));
            CreateMap<DispatchingPlacement, DispatchingPlacementWithReceivingPlacementDispatchingPalletAndPalletPositionObjectResponse>()
                .ForMember(d => d.ReceivingPlacement, o => o.MapFrom(s => s.ReceivingPlacement))
                .ForMember(d => d.Dispatching, o => o.MapFrom(s => s.Dispatching))
                .ForMember(d => d.Pallet, o => o.MapFrom(s => s.Dispatching))
                .ForMember(d => d.PalletPosition, o => o.MapFrom(s => s.PalletPosition))
                .ForMember(d => d.Creator, o => o.MapFrom(s => s.Creator))
                .ForMember(d => d.Approver, o => o.MapFrom(s => s.Approver));
        }
    }
}