using AutoMapper;

namespace CSMS_API.Models
{
    public class ReceivingProductMapper : Profile
    {
        public ReceivingProductMapper()
        {
            CreateMap<CreateReceivingProductRequest, ReceivingProduct>();
            CreateMap<UpdateReceivingProductRequest, ReceivingProduct>();
            CreateMap<ReceivingProduct, ReceivingProductOnlyResponse>();
            CreateMap<ReceivingProduct, ReceivingProductWithReceivingAndProductResponse>()
                .ForMember(d => d.ReceivingID, o => o.MapFrom(s => s.Receiving.ID))
                .ForMember(d => d.DocumentNo, o => o.MapFrom(s => s.Receiving.DocumentNo))
                .ForMember(d => d.CVNumber, o => o.MapFrom(s => s.Receiving.CVNumber))
                .ForMember(d => d.PlateNumber, o => o.MapFrom(s => s.Receiving.PlateNumber))
                .ForMember(d => d.ArrivalDate, o => o.MapFrom(s => s.Receiving.ArrivalDate))
                .ForMember(d => d.UnloadingStart, o => o.MapFrom(s => s.Receiving.UnloadingStart))
                .ForMember(d => d.UnloadingEnd, o => o.MapFrom(s => s.Receiving.UnloadingEnd))
                .ForMember(d => d.ProductID, o => o.MapFrom(s => s.Product.ID))
                .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Product.Category.Name))
                .ForMember(d => d.CompanyName, o => o.MapFrom(s => s.Product.Company.Name))
                .ForMember(d => d.CompanyLocation, o => o.MapFrom(s => s.Product.Company.Location))
                .ForMember(d => d.CompanyEmail, o => o.MapFrom(s => s.Product.Company.Email))
                .ForMember(d => d.CompanyPhoneNumber, o => o.MapFrom(s => s.Product.Company.PhoneNumber))
                .ForMember(d => d.CompanyTelephoneNumber, o => o.MapFrom(s => s.Product.Company.TelephoneNumber))
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
            CreateMap<ReceivingProduct, ReceivingProductWithReceivingAndProductObjectResponse>()
                .ForMember(d => d.Receiving, o => o.MapFrom(s => s.Receiving))
                .ForMember(d => d.Product, o => o.MapFrom(s => s.Product));
        }
    }
    public class ReceivingPlacementMapper : Profile
    {
        public ReceivingPlacementMapper()
        {
            CreateMap<CreateReceivingPlacementRequest, ReceivingPlacement>();
            CreateMap<UpdateReceivingPlacementRequest, ReceivingPlacement>();
            CreateMap<ReceivingPlacement, ReceivingPlacementWithReceivingProductReceivingDetailPalletAndPalletPositionResponse>()
                .ForMember(d => d.ReceivingProductID, o => o.MapFrom(s => s.ReceivingProduct.ID))
                .ForMember(d => d.TotalQuantity, o => o.MapFrom(s => s.ReceivingProduct.TotalQuantity))
                .ForMember(d => d.TotalWeight, o => o.MapFrom(s => s.ReceivingProduct.TotalWeight))
                .ForMember(d => d.ReceivingDetailID, o => o.MapFrom(s => s.ReceivingDetail.ID))
                .ForMember(d => d.ExpirationDate, o => o.MapFrom(s => s.ReceivingDetail.ExpirationDate))
                .ForMember(d => d.ProductionDate, o => o.MapFrom(s => s.ReceivingDetail.ProductionDate))
                .ForMember(d => d.QuantityInPallet, o => o.MapFrom(s => s.ReceivingDetail.QuantityInPallet))
                .ForMember(d => d.DUQuantity, o => o.MapFrom(s => s.ReceivingDetail.DUQuantity))
                .ForMember(d => d.ReceivingDetailTotalWeight, o => o.MapFrom(s => s.ReceivingDetail.TotalWeight))
                .ForMember(d => d.Remark, o => o.MapFrom(s => s.ReceivingDetail.Remark))
                .ForMember(d => d.PalletID, o => o.MapFrom(s => s.Pallet.ID))
                .ForMember(d => d.Type, o => o.MapFrom(s => s.Pallet.Type))
                .ForMember(d => d.Number, o => o.MapFrom(s => s.Pallet.Number))
                .ForMember(d => d.PalletPositionID, o => o.MapFrom(s => s.PalletPosition.ID))
                .ForMember(d => d.Wing, o => o.MapFrom(s => s.PalletPosition.Wing))
                .ForMember(d => d.Floor, o => o.MapFrom(s => s.PalletPosition.Floor))
                .ForMember(d => d.Column, o => o.MapFrom(s => s.PalletPosition.Column))
                .ForMember(d => d.Side, o => o.MapFrom(s => s.PalletPosition.Side));
            CreateMap<ReceivingPlacement, ReceivingPlacementWithReceivingProductReceivingDetailPalletAndPalletPositionObjectResponse>()
                .ForMember(d => d.ReceivingProduct, o => o.MapFrom(s => s.ReceivingProduct))
                .ForMember(d => d.ReceivingDetail, o => o.MapFrom(s => s.ReceivingDetail))
                .ForMember(d => d.Pallet, o => o.MapFrom(s => s.Pallet))
                .ForMember(d => d.PalletPosition, o => o.MapFrom(s => s.PalletPosition));
        }
    }
}