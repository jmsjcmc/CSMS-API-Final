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
    }
}