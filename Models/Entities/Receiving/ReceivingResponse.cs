namespace CSMS_API.Models
{
    public class ReceivingOnlyResponse
    {
        public int ID { get; set; }
        public string? DocumentNo { get; set; }
        public string? CVNumber { get; set; }
        public string? PlateNumber { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public string? UnloadingStart { get; set; }
        public string? UnloadingEnd { get; set; }
        public UserWithBusinessUnitAndPositionObjectResponse? Creator { get; set; }
        public UserWithBusinessUnitAndPositionObjectResponse? Approver { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
    public class ReceivingWithReceivingDetailResponse
    {
        public int ID { get; set; }
        public string? DocumentNo { get; set; }
        public string? CVNumber { get; set; }
        public string? PlateNumber { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public string? UnloadingStart { get; set; }
        public string? UnloadingEnd { get; set; }
        public UserWithBusinessUnitAndPositionObjectResponse? Creator { get; set; }
        public UserWithBusinessUnitAndPositionObjectResponse? Approver { get; set; }
        public DateTime? CreatedOn { get; set; }
        public List<ReceivingDetailOnlyResponse>? ReceivingDetail { get; set; } // RECEIVING DETAIL
    }
    public class ReceivingDetailOnlyResponse
    {
        public int ID { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? ProductionDate { get; set; }
        public int? QuantityInPallet { get; set; }
        public int? DUQuantity { get; set; }
        public double? TotalWeight { get; set; }
        public string? Remark { get; set; }
        public UserWithBusinessUnitAndPositionObjectResponse? Creator { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
    public class ReceivingDetailWithReceivingAndProductResponse
    {
        public int ID { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? ProductionDate { get; set; }
        public int? QuantityInPallet { get; set; }
        public int? DUQuantity { get; set; }
        public double? TotalWeight { get; set; }
        public string? Remark { get; set; }
        public UserWithBusinessUnitAndPositionObjectResponse? Creator { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ReceivingID { get; set; } // RECEIVING
        public string? DocumentNo { get; set; } // RECEIVING
        public string? CVNumber { get; set; } // RECEIVING
        public string? PlateNumber { get; set; } // RECEIVING
        public DateTime? ArrivalDate { get; set; } // RECEIVING
        public string? UnloadingStart { get; set; } // RECEIVING
        public string? UnloadingEnd { get; set; } // RECEIVING
        public int? ProductID { get; set; } // PRODUCT
        public string? ProductCode { get; set; } // PRODUCT
        public string? ProductName { get; set; } // PRODUCT
        public string? Variant { get; set; } // PRODUCT
        public string? SKU { get; set; } // PRODUCT
        public string? ProductPackaging { get; set; } // PRODUCT
        public string? DeliveryUnit { get; set; } // PRODUCT
        public string? UOM { get; set; } // PRODUCT
        public string? Unit { get; set; } // PRODUCT
        public int? Quantity { get; set; } // PRODUCT
        public double? Weight { get; set; } // PRODUCT
    }
    public class ReceivingDetailWithReceivingAndProductObjectResponse
    {
        public int ID { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? ProductionDate { get; set; }
        public int? QuantityInPallet { get; set; }
        public int? DUQuantity { get; set; }
        public double? TotalWeight { get; set; }
        public string? Remark { get; set; }
        public UserWithBusinessUnitAndPositionObjectResponse? Creator { get; set; }
        public DateTime? CreatedOn { get; set; }
        public ReceivingOnlyResponse? Receiving { get; set; } // RECEIVING
        public ProductOnlyResponse? Product { get; set; } // PRODUCT
    }
}