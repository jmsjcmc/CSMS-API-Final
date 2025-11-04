using Magicodes.ExporterAndImporter.Core;
using Magicodes.ExporterAndImporter.Excel;

namespace CSMS_API.Utils
{
    [ExcelImporter(IsLabelingError = true)]
    public class ProductImportRequest
    {
        [ImporterHeader(Name = "Category Name")]
        public string? CategoryName { get; set; }
        [ImporterHeader(Name = "Company Name")]
        public string? CompanyName { get; set; }
        [ImporterHeader(Name = "Product Code")]
        public string? ProductCode { get; set; }
        [ImporterHeader(Name = "Product Name")]
        public string? ProductName { get; set; }
        [ImporterHeader(Name = "Variant")]
        public string? Variant { get; set; }
        [ImporterHeader(Name = "SKU")]
        public string? SKU { get; set; }
        [ImporterHeader(Name = "Product Packaging")]
        public string? ProductPackaging { get; set; }
        [ImporterHeader(Name = "Delivery Unit")]
        public string? DeliveryUnit { get; set; }
        [ImporterHeader(Name = "UOM")]
        public string? UOM { get; set; }
        [ImporterHeader(Name = "Unit")]
        public string? Unit { get; set; }
        [ImporterHeader(Name = "Quantity")]
        public int? Quantity { get; set; }
        [ImporterHeader(Name = "Weight")]
        public double? Weight { get; set; }
    }
}