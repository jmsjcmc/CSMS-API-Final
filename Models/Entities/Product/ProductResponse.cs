namespace CSMS_API.Models
{
    public class ProductOnlyResponse
    {
        public int ID { get; set; }
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
        public DateTime? CreatedOn { get; set; }
        public RecordStatus? RecordStatus { get; set; }
    }
    public class ProductWithCategoryAndCompanyResponse
    {
        public int ID { get; set; }
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
        public DateTime? CreatedOn { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public int? CategoryID { get; set; } // CATEGORY
        public string? CategoryName { get; set; } // CATEGORY
        public int? CompanyID { get; set; } // COMPANY
        public string? CompanyName { get; set; } // COMPANY
        public string? CompanyLocation { get; set; } // COMPANY
        public string? CompanyEmail { get; set; } // COMPANY
        public string? CompanyPhoneNumber { get; set; } // COMPANY
        public string? CompanyTelephoneNumber { get; set; } // COMPANY
    }
    public class ProductWIthCategoryAndCompanyObjectResponse
    {
        public int ID { get; set; }
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
        public DateTime? CreatedOn { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public CategoryResponse? Category { get; set; } // CATEGORY
        public CompanyOnlyResponse? Company { get; set; } // COMPANY
    }
    public class CategoryResponse
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public RecordStatus? RecordStatus { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}