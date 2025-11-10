namespace CSMS_API.Models
{
    public class CreateDispatchingPlacementRequest
    {
        public int? ReceivingPlacementID { get; set; }
        public int? DispatchingDetailID { get; set; }
        public int? PalletID { get; set; }
        public int? PalletPositionID { get; set; }
        public int? Quantity { get; set; }
        public double? Weight { get; set; }
    }
    public class UpdateDispatchingPlacementRequest
    {
        public int? ReceivingPlacementID { get; set; }
        public int? DispatchingDetailID { get; set; }
        public int? PalletID { get; set; }
        public int? PalletPositionID { get; set; }
        public int? Quantity { get; set; }
        public double? Weight { get; set; }
    }
}