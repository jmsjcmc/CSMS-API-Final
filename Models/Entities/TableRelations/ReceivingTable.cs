namespace CSMS_API.Models
{
    public class ReceivingProduct
    {
        public int ID { get; set; }
        public int? ReceivingID { get; set; }
        public Receiving? Receiving { get; set; }
        public int? ProductID { get; set; }
        public Product? Product { get; set; }
        public int? TotalQuantity { get; set; }
        public double? TotalWeight { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public ICollection<ReceivingProductLog>? ReceivingProductLog { get; set; }
        public ICollection<ReceivingPlacement>? ReceivingPlacement { get; set; }
    }
    public class ReceivingProductLog
    {
        public int ID { get; set; }
        public int? ReceivingProductID { get; set; }
        public ReceivingProduct? ReceivingProduct { get; set; }
        public int? UpdaterID { get; set; }
        public User? Updater { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
    public class ReceivingPlacement
    {
        public int ID { get; set; }
        public int? ReceivingProductID { get; set; }
        public ReceivingProduct? ReceivingProduct { get; set; }
        public int? ReceivingDetailID { get; set; }
        public ReceivingDetail? ReceivingDetail { get; set; }
        public int? PalletID { get; set; }
        public Pallet? Pallet { get; set; }
        public int? PalletPositionID { get; set; }
        public PalletPosition? PalletPosition { get; set; }
        public int? Quantity { get; set; }
        public double? Weight { get; set; }
        public string? TaggingNumber { get; set; }
        public string? CrateNumber { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public int? ApproverID { get; set; }
        public User? Approver { get; set; }
        public ICollection<ReceivingPlacementLog>? ReceivingPlacementLog { get; set; }
    }
    public class ReceivingPlacementLog
    {
        public int ID { get; set; }
        public int? ReceivingPlacementID { get; set; }
        public ReceivingPlacement? ReceivingPlacement { get; set; }
        public int? UpdaterID { get; set; }
        public User? Updater { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}