namespace CSMS_API.Models
{
    public class DispatchingPlacement
    {
        public int ID { get; set; }
        public int? ReceivingPlacementID { get; set; }
        public ReceivingPlacement? ReceivingPlacement { get; set; }
        public int? DispatchingDetailID { get; set; }
        public DispatchingDetail? DispatchingDetail { get; set; }
        public int? PalletID { get; set; }
        public Pallet? Pallet { get; set; }
        public int? PalletPositionID { get; set; }
        public PalletPosition? PalletPosition { get; set; }
        public int? Quantity { get; set; }
        public double? Weight { get; set; }
        public ICollection<DispatchingPlacementLog>? DispatchingPlacementLog { get; set; }
    }
    public class DispatchingPlacementLog
    {
        public int ID { get; set; }
        public int? DispatchingPlacementID { get; set; }
        public DispatchingPlacement? DispatchingPlacement { get; set; }
        public int? UpdaterID { get; set; }
        public User? Updater { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}