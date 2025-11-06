namespace CSMS_API.Models
{
    public class Product
    {
        public int ID { get; set; }
        public int? CategoryID { get; set; }
        public Category? Category { get; set; }
        public int? CompanyID { get; set; }
        public Company? Company { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public string? Variant { get; set; }
        public string? SKU { get; set; }
        public string? ProductPackaging { get; set; }
        public string? DeliveryUnit { get; set; }
        public string? UOM { get; set; }
        public string? Unit { get; set; }
        public int? Quantity { get; set; }
        public double? Weight { get; set; }
        public int? CreatorID { get; set; }
        public User? Creator { get; set; }
        public DateTime? CreatedOn { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public ICollection<ProductLog>? ProductLog { get; set; }
        public ICollection<ReceivingDetail>? ReceivingDetail { get; set; }
        public ICollection<ReceivingProduct>? ReceivingProduct { get; set; }
    }
    public class ProductLog
    {
        public int ID { get; set; }
        public int? ProductID { get; set; }
        public Product? Product { get; set; }
        public int? UpdaterID { get; set; }
        public User? Updater { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
    public class Category
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public int? CreatorID { get; set; }
        public User? Creator { get; set; }
        public DateTime? CreatedOn { get; set; }
        public ICollection<Product>? Product { get; set; }
        public ICollection<CategoryLog>? CategoryLog { get; set; }
    }
    public class CategoryLog
    {
        public int ID { get; set; }
        public int? CategoryID { get; set; }
        public Category? Category { get; set; }
        public int? UpdaterID { get; set; }
        public User? Updater { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}