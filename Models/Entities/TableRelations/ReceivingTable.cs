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

    }
}