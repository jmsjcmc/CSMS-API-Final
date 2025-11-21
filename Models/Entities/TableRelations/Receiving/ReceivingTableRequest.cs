namespace CSMS_API.Models
{
    public class CreateReceivingProductRequest
    {
        public int? ReceivingID { get; set; }
        public int? ProductID { get; set; }
        public int? TotalQuantity { get; set; }
        public double? TotalWeight { get; set; }
    }
    public class UpdateReceivingProductRequest
    {
        public int? ReceivingID { get; set; }
        public int? ProductID { get; set; }
        public int? TotalQuantity { get; set; }
        public double? TotalWeight { get; set; }
    }
    public class CreateReceivingPlacementRequest
    {
        public int? ReceivingProductID { get; set; }
        public int? ReceivingDetailID { get; set; }
        public int? PalletID { get; set; }
        public PalletOccupationStatus? PalletOccupationStatus { get; set; }
        public int? PalletPositionID { get; set; }
        public int? Quantity { get; set; }
        public double? Weight { get; set; }
        public string? TaggingNumber { get; set; }
        public string? CrateNumber { get; set; }
    }
    public class UpdateReceivingPlacementRequest
    {
        public int? ReceivingProductID { get; set; }
        public int? ReceivingDetailID { get; set; }
        public int? PalletID { get; set; }
        public int? PalletPositionID { get; set; }
        public int? Quantity { get; set; }
        public double? Weight { get; set; }
        public string? TaggingNumber { get; set; }
        public string? CrateNumber { get; set; }
    }
}