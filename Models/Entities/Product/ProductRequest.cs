namespace CSMS_API.Models
{
    public class CreateProductRequest
    {
        public int? CategoryID { get; set; }
        public int? CompanyID { get; set; }
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
    }
    public class UpdateProductRequest
    {
        public int? CategoryID { get; set; }
        public int? CompanyID { get; set; }
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
    }
}