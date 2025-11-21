namespace CSMS_API.Models
{
    public class ReceivingProductOnlyResponse
    {
        public int ID { get; set; }
        public int? TotalQuantity { get; set; }
        public double? TotalWeight { get; set; }
        public RecordStatus? RecordStatus { get; set; }
    }
    public class ReceivingProductWithReceivingAndProductResponse
    {
        public int ID { get; set; }
        public int? ReceivingID { get; set; } // RECEIVING
        public string? DocumentNo { get; set; } // RECEIVING
        public string? CVNumber { get; set; } // RECEIVING
        public string? PlateNumber { get; set; } // RECEIVING
        public DateTime? ArrivalDate { get; set; } // RECEIVING
        public string? UnloadingStart { get; set; } // RECEIVING
        public string? UnloadingEnd { get; set; } // RECEIVING
        public int? ProductID { get; set; } // PRODUCT
        public string? CategoryName { get; set; } // PRODUCT, CATEGORY
        public string? CompanyName { get; set; } // PRODUCT, CATEGORY
        public string? CompanyLocation { get; set; } // PRODUCT, CATEGORY
        public string? CompanyEmail { get; set; } // PRODUCT, CATEGORY
        public string? CompanyPhoneNumber { get; set; } // PRODUCT, CATEGORY
        public string? CompanyTelephoneNumber { get; set; } // PRODUCT, CATEGORY
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
        public int? TotalQuantity { get; set; }
        public double? TotalWeight { get; set; }
        public RecordStatus? RecordStatus { get; set; }
    }
    public class ReceivingProductWithReceivingAndProductObjectResponse
    {
        public int ID { get; set; }
        public ReceivingOnlyResponse? Receiving { get; set; } // RECEIVING
        public ProductOnlyResponse? Product { get; set; } // PRODUCT
        public int? TotalQuantity { get; set; }
        public double? TotalWeight { get; set; }
        public RecordStatus? RecordStatus { get; set; }
    }
    public class ReceivingPlacementOnlyResponse
    {
        public int ID { get; set; }
        public int? Quantity { get; set; }
        public double? Weight { get; set; }
        public string? TaggingNumber { get; set; }
        public string? CrateNumber { get; set; }
        public RecordStatus? RecordStatus { get; set; }
    }
    public class ReceivingPlacementWithReceivingProductReceivingDetailPalletAndPalletPositionResponse
    {
        public int ID { get; set; }
        public int? ReceivingProductID { get; set; } // RECEIVING PRODUCT
        public int? TotalQuantity { get; set; } // RECEIVING PRODUCT
        public double? TotalWeight { get; set; } // RECEIVING PRODUCT
        public int? ReceivingDetailID { get; set; } // RECEIVING DETAIL
        public DateTime? ExpirationDate { get; set; } // RECEIVING DETAIL
        public DateTime? ProductionDate { get; set; } // RECEIVING DETAIL
        public int? QuantityInPallet { get; set; } // RECEIVING DETAIL
        public int? DUQuantity { get; set; } // RECEIVING DETAIL
        public double? ReceivingDetailTotalWeight { get; set; } // RECEIVING DETAIL
        public string? Remark { get; set; } // RECEIVING DETAIL
        public int? PalletID { get; set; } // PALLET
        public string? Type { get; set; } // PALLET
        public string? Number { get; set; } // PALLET
        public int? PalletPositionID { get; set; } // PALLET POSITION
        public string? Wing { get; set; } // PALLET POSITION
        public string? Floor { get; set; } // PALLET POSITION
        public string? Column { get; set; } // PALLET POSITION
        public string? Side { get; set; } // PALLET POSITION
        public int? Quantity { get; set; }
        public double? Weight { get; set; }
        public string? TaggingNumber { get; set; }
        public string? CrateNumber { get; set; }
        public RecordStatus? RecordStatus { get; set; }
    }
    public class ReceivingPlacementWithReceivingProductReceivingDetailPalletAndPalletPositionObjectResponse
    {
        public int ID { get; set; }
        public ReceivingProductOnlyResponse? ReceivingProduct { get; set; } // RECEIVING PRODUCT
        public ReceivingDetailOnlyResponse? ReceivingDetail { get; set; } // RECEIVING DETAIL
        public PalletOnlyResponse? Pallet { get; set; } // PALLET
        public PalletPositionOnlyResponse? PalletPosition { get; set; } // PALLET POSITION
        public int? Quantity { get; set; }
        public double? Weight { get; set; }
        public string? TaggingNumber { get; set; }
        public string? CrateNumber { get; set; }
        public RecordStatus? RecordStatus { get; set; }
    }
}