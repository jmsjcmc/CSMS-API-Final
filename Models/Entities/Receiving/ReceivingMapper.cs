using AutoMapper;
using CSMS_API.Utils;
using System.Security.Claims;

namespace CSMS_API.Models
{
    public class ReceivingMapper : Profile
    {
        public ReceivingMapper()
        {
            CreateMap<CreateReceivingRequest, Receiving>();
            CreateMap<UpdateReceivingRequest, Receiving>()
                .ForMember(d => d.ReceivingDetail, o => o.MapFrom(s => s.ReceivingDetail));
        }
    }
    public class ReceivingDetailMapper : Profile
    {
        public ReceivingDetailMapper()
        {
            CreateMap<CreateReceivingDetailRequest, ReceivingDetail>();
            CreateMap<UpdateReceivingDetailRequest, ReceivingDetail>();
        }
    }
    public static class ManualReceivingMapper
    {
        public static void ManualReceivingRequestMapping(UpdateReceivingRequest request, Receiving receiving)
        {
            receiving.DocumentNo = request.DocumentNo;
            receiving.CVNumber = request.CVNumber;
            receiving.PlateNumber = request.PlateNumber;
            receiving.ArrivalDate = request.ArrivalDate;
            receiving.UnloadingStart = request.UnloadingStart;
            receiving.UnloadingEnd = request.UnloadingEnd;
        }
        public static void ManualReceivingDetaiRequestlMapping(UpdateReceivingRequest request, Receiving receiving, ClaimsPrincipal user)
        {
            foreach (var receivingDetail in request.ReceivingDetail)
            {
                receiving.ReceivingDetail.Add(new ReceivingDetail
                {
                    ReceivingID = receiving.ID,
                    ProductID = receivingDetail.ProductID,
                    ExpirationDate = receivingDetail.ExpirationDate,
                    ProductionDate = receivingDetail.ProductionDate,
                    QuantityInPallet = receivingDetail.QuantityInPallet,
                    DUQuantity = receivingDetail.DUQuantity,
                    TotalWeight = receivingDetail.TotalWeight,
                    Remark = receivingDetail.Remark,
                    CreatorID = AuthenticationHelper.GetUserIDAsync(user),
                    CreatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
                });
            }
        }
        public static ReceivingOnlyResponse ManualReceivingOnlyResponse(Receiving receiving)
        {
            return new ReceivingOnlyResponse
            {
                ID = receiving.ID,
                DocumentNo = receiving.DocumentNo,
                CVNumber = receiving.CVNumber,
                PlateNumber = receiving.PlateNumber,
                ArrivalDate = receiving.ArrivalDate,
                UnloadingStart = receiving.UnloadingStart,
                UnloadingEnd = receiving.UnloadingEnd,
                Creator = receiving.Creator != null
                ? ManualUserMapping.ManualUserWithBusinessUnitAndPositionObjectResponse(receiving.Creator)
                : null,
                Approver = receiving.Approver != null
                ? ManualUserMapping.ManualUserWithBusinessUnitAndPositionObjectResponse(receiving.Approver)
                : null,
                CreatedOn = receiving.CreatedOn
            };
        }
        public static List<ReceivingOnlyResponse> ManualReceivingOnlyListResponse(List<Receiving> receivings)
        {
            return receivings
                .Select(ManualReceivingOnlyResponse)
                .ToList();
        }
        public static ReceivingWithReceivingDetailResponse ManualReceivingWithReceivingDetailResponse(Receiving receiving)
        {
            return new ReceivingWithReceivingDetailResponse
            {
                ID = receiving.ID,
                DocumentNo = receiving.DocumentNo,
                CVNumber = receiving.CVNumber,
                PlateNumber = receiving.PlateNumber,
                ArrivalDate = receiving.ArrivalDate,
                UnloadingStart = receiving.UnloadingStart,
                UnloadingEnd = receiving.UnloadingEnd,
                Creator = receiving.Creator != null
                ? ManualUserMapping.ManualUserWithBusinessUnitAndPositionObjectResponse(receiving.Creator)
                : null,
                Approver = receiving.Approver != null
                ? ManualUserMapping.ManualUserWithBusinessUnitAndPositionObjectResponse(receiving.Approver)
                : null,
                CreatedOn = receiving.CreatedOn,
                ReceivingDetail = receiving.ReceivingDetail != null
                ? ManualReceivingDetailMapping.ManualReceivingDetailOnlyListResponse(receiving.ReceivingDetail.ToList())
                : null,
            };
        }
        public static List<ReceivingWithReceivingDetailResponse> ManualReceivingWithReceivingDetailListResponse(List<Receiving> receivings)
        {
            return receivings
                .Select(ManualReceivingWithReceivingDetailResponse)
                .ToList();
        }
    }
    public static class ManualReceivingDetailMapping
    {
        public static ReceivingDetailOnlyResponse ManualReceivingDetailOnlyResponse(ReceivingDetail receivingDetail)
        {
            return new ReceivingDetailOnlyResponse
            {
                ID = receivingDetail.ID,
                ExpirationDate = receivingDetail.ExpirationDate,
                ProductionDate = receivingDetail.ProductionDate,
                QuantityInPallet = receivingDetail.QuantityInPallet,
                DUQuantity = receivingDetail.DUQuantity,
                TotalWeight = receivingDetail.TotalWeight,
                Remark = receivingDetail.Remark,
                Creator = receivingDetail.Creator != null
                ? ManualUserMapping.ManualUserWithBusinessUnitAndPositionObjectResponse(receivingDetail.Creator)
                : null,
                CreatedOn = receivingDetail.CreatedOn
            };
        }
        public static List<ReceivingDetailOnlyResponse> ManualReceivingDetailOnlyListResponse(List<ReceivingDetail> receivingDetails)
        {
            return receivingDetails
                .Select(ManualReceivingDetailOnlyResponse)
                .ToList();
        }
        public static ReceivingDetailWithReceivingAndProductResponse ManualReceivingDetailWithReceivingAndProductResponse(ReceivingDetail receivingDetail)
        {
            return new ReceivingDetailWithReceivingAndProductResponse
            {
                ID = receivingDetail.ID,
                ExpirationDate = receivingDetail.ExpirationDate,
                ProductionDate = receivingDetail.ProductionDate,
                QuantityInPallet = receivingDetail.QuantityInPallet,
                DUQuantity = receivingDetail.DUQuantity,
                TotalWeight = receivingDetail.TotalWeight,
                Remark = receivingDetail.Remark,
                Creator = receivingDetail.Creator != null
                ? ManualUserMapping.ManualUserWithBusinessUnitAndPositionObjectResponse(receivingDetail.Creator)
                : null,
                CreatedOn = receivingDetail.CreatedOn,
                ReceivingID = receivingDetail.ReceivingID,
                DocumentNo = receivingDetail.Receiving.DocumentNo,
                CVNumber = receivingDetail.Receiving.CVNumber,
                PlateNumber = receivingDetail.Receiving.PlateNumber,
                ArrivalDate = receivingDetail.Receiving.ArrivalDate,
                UnloadingStart = receivingDetail.Receiving.UnloadingStart,
                UnloadingEnd = receivingDetail.Receiving.UnloadingEnd,
                ProductID = receivingDetail.ProductID,
                ProductCode = receivingDetail.Product.ProductCode,
                ProductName = receivingDetail.Product.ProductName,
                Variant = receivingDetail.Product.Variant,
                SKU = receivingDetail.Product.SKU,
                ProductPackaging = receivingDetail.Product.ProductPackaging,
                DeliveryUnit = receivingDetail.Product.DeliveryUnit,
                UOM = receivingDetail.Product.UOM,
                Unit = receivingDetail.Product.Unit,
                Quantity = receivingDetail.Product.Quantity,
                Weight = receivingDetail.Product.Weight
            };
        }
        public static List<ReceivingDetailWithReceivingAndProductResponse> ManualReceivingDetailWithReceivingAndProductListResponse(List<ReceivingDetail> receivingDetails)
        {
            return receivingDetails
                .Select(ManualReceivingDetailWithReceivingAndProductResponse)
                .ToList();
        }
        public static ReceivingDetailWithReceivingAndProductObjectResponse ManualReceivingDetailWithReceivingAndProductObjectResponse(ReceivingDetail receivingDetail)
        {
            return new ReceivingDetailWithReceivingAndProductObjectResponse
            {
                ID = receivingDetail.ID,
                ExpirationDate = receivingDetail.ExpirationDate,
                ProductionDate = receivingDetail.ProductionDate,
                QuantityInPallet = receivingDetail.QuantityInPallet,
                DUQuantity = receivingDetail.DUQuantity,
                TotalWeight = receivingDetail.TotalWeight,
                Remark = receivingDetail.Remark,
                Creator = receivingDetail.Creator != null
                ? ManualUserMapping.ManualUserWithBusinessUnitAndPositionObjectResponse(receivingDetail.Creator)
                : null,
                CreatedOn = receivingDetail.CreatedOn,
                Receiving = receivingDetail.Receiving != null
                ? ManualReceivingMapper.ManualReceivingOnlyResponse(receivingDetail.Receiving)
                : null,
                Product = receivingDetail.Product != null
                ? ManualProductMapping.ManualProductOnlyResponse(receivingDetail.Product)
                : null
            };
        }
        public static List<ReceivingDetailWithReceivingAndProductObjectResponse> ManualReceivingDetailWithReceivingAndProductObjectListResponse(List<ReceivingDetail> receivingDetails)
        {
            return receivingDetails
                .Select(ManualReceivingDetailWithReceivingAndProductObjectResponse)
                .ToList();
        }
    }
}