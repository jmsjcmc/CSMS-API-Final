using AutoMapper;

namespace CSMS_API.Models
{
    public class ReceivingMapper : Profile
    {
        public ReceivingMapper()
        {
            CreateMap<CreateReceivingRequest, Receiving>();
            CreateMap<UpdateReceivingRequest, Receiving>()
                .ForMember(d => d.ReceivingDetail, o => o.MapFrom(s => s.ReceivingDetail));
            CreateMap<Receiving, ReceivingOnlyResponse>()
                .ForMember(d => d.Creator, o => o.MapFrom(s => s.Creator))
                .ForMember(d => d.Approver, o => o.MapFrom(s => s.Approver));
            CreateMap<Receiving, ReceivingWithReceivingDetailResponse>()
                .ForMember(d => d.ReceivingDetail, o => o.MapFrom(s => s.ReceivingDetail))
                .ForMember(d => d.Creator, o => o.MapFrom(s => s.Creator))
                .ForMember(d => d.Approver, o => o.MapFrom(s => s.Approver));
        }
    }
    public class ReceivingDetailMapper : Profile
    {
        public ReceivingDetailMapper()
        {
            CreateMap<CreateReceivingDetailRequest, ReceivingDetail>();
            CreateMap<UpdateReceivingDetailRequest, ReceivingDetail>();
            CreateMap<ReceivingDetail, ReceivingDetailOnlyResponse>();
            CreateMap<ReceivingDetail, ReceivingDetailWithReceivingAndProductResponse>()
                .ForMember(d => d.ReceivingID, o => o.MapFrom(s => s.Receiving.ID))
                .ForMember(d => d.DocumentNo, o => o.MapFrom(s => s.Receiving.DocumentNo))
                .ForMember(d => d.CVNumber, o => o.MapFrom(s => s.Receiving.CVNumber))
                .ForMember(d => d.PlateNumber, o => o.MapFrom(s => s.Receiving.PlateNumber))
                .ForMember(d => d.ArrivalDate, o => o.MapFrom(s => s.Receiving.ArrivalDate))
                .ForMember(d => d.UnloadingStart, o => o.MapFrom(s => s.Receiving.UnloadingStart))
                .ForMember(d => d.UnloadingEnd, o => o.MapFrom(s => s.Receiving.UnloadingEnd))
                .ForMember(d => d.ProductID, o => o.MapFrom(s => s.Product.ID))
                .ForMember(d => d.ProductCode, o => o.MapFrom(s => s.Product.ProductCode))
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.Product.ProductName))
                .ForMember(d => d.Variant, o => o.MapFrom(s => s.Product.Variant))
                .ForMember(d => d.SKU, o => o.MapFrom(s => s.Product.SKU))
                .ForMember(d => d.ProductPackaging, o => o.MapFrom(s => s.Product.ProductPackaging))
                .ForMember(d => d.DeliveryUnit, o => o.MapFrom(s => s.Product.DeliveryUnit))
                .ForMember(d => d.UOM, o => o.MapFrom(s => s.Product.UOM))
                .ForMember(d => d.Unit, o => o.MapFrom(s => s.Product.Unit))
                .ForMember(d => d.Quantity, o => o.MapFrom(s => s.Product.Quantity))
                .ForMember(d => d.Weight, o => o.MapFrom(s => s.Product.Weight));
            CreateMap<ReceivingDetail, ReceivingDetailWithReceivingAndProductObjectResponse>()
                .ForMember(d => d.Receiving, o => o.MapFrom(s => s.Receiving))
                .ForMember(d => d.Product, o => o.MapFrom(s => s.Product));
        }
    }
}