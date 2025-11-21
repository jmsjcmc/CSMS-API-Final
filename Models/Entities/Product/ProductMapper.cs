using AutoMapper;

namespace CSMS_API.Models
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<CreateProductRequest, Product>();
            CreateMap<UpdateProductRequest, Product>();
        }
    }
    public static class ManualProductMapping
    {
        public static ProductOnlyResponse ManualProductOnlyResponse(Product product)
        {
            return new ProductOnlyResponse
            {
                ID = product.ID,
                ProductCode = product.ProductCode,
                ProductName = product.ProductName,
                Variant = product.Variant,
                SKU = product.SKU,
                ProductPackaging = product.ProductPackaging,
                DeliveryUnit = product.DeliveryUnit,
                UOM = product.UOM,
                Unit = product.Unit,
                Quantity = product.Quantity,
                Weight = product.Weight,
                CreatedOn = product.CreatedOn,
                RecordStatus = product.RecordStatus
            };
        }
        public static List<ProductOnlyResponse> ManualProductOnlyListResponse(List<Product> products)
        {
            return products
                .Select(ManualProductOnlyResponse)
                .ToList();
        }
        public static ProductWithCategoryAndCompanyResponse ManualProductWithCategoryAndCompanyResponse(Product product)
        {
            return new ProductWithCategoryAndCompanyResponse
            {
                ID = product.ID,
                ProductCode = product.ProductCode,
                ProductName = product.ProductName,
                Variant = product.Variant,
                SKU = product.SKU,
                ProductPackaging = product.ProductPackaging,
                DeliveryUnit = product.DeliveryUnit,
                UOM = product.UOM,
                Unit = product.Unit,
                Quantity = product.Quantity,
                Weight = product.Weight,
                CreatedOn = product.CreatedOn,
                RecordStatus = product.RecordStatus,
                CategoryID = product.CategoryID,
                CategoryName = product.Category.Name,
                CompanyID = product.CompanyID,
                CompanyName = product.Company.Name,
                CompanyLocation = product.Company.Location,
                CompanyEmail = product.Company.Email,
                CompanyPhoneNumber = product.Company.PhoneNumber,
                CompanyTelephoneNumber = product.Company.TelephoneNumber
            };
        }
        public static List<ProductWithCategoryAndCompanyResponse> ManualProductWithCategoryAndCompanyListResponse(List<Product> products)
        {
            return products
                .Select(ManualProductWithCategoryAndCompanyResponse)
                .ToList();
        }
        public static ProductWIthCategoryAndCompanyObjectResponse ManualProductWIthCategoryAndCompanyObjectResponse(Product product)
        {
            return new ProductWIthCategoryAndCompanyObjectResponse
            {
                ID = product.ID,
                ProductCode = product.ProductCode,
                ProductName = product.ProductName,
                Variant = product.Variant,
                SKU = product.SKU,
                ProductPackaging = product.ProductPackaging,
                DeliveryUnit = product.DeliveryUnit,
                UOM = product.UOM,
                Unit = product.Unit,
                Quantity = product.Quantity,
                Weight = product.Weight,
                CreatedOn = product.CreatedOn,
                RecordStatus = product.RecordStatus,
                Category = product.Category != null
                ? ManualCategoryMapping.ManualCategoryResponse(product.Category)
                : null,
                Company = product.Company != null
                ? ManualCompanyMapping.ManualCompanyOnlyResponse(product.Company)
                : null
            };
        }
        public static List<ProductWIthCategoryAndCompanyObjectResponse> ManualProductWIthCategoryAndCompanyObjectListResponse(List<Product> products)
        {
            return products
                .Select(ManualProductWIthCategoryAndCompanyObjectResponse)
                .ToList();
        }
    }
    public static class ManualCategoryMapping
    {
        public static CategoryResponse ManualCategoryResponse(Category category)
        {
            return new CategoryResponse
            {
                ID = category.ID,
                Name = category.Name,
                RecordStatus = category.RecordStatus,
                CreatedOn = category.CreatedOn
            };
        }
        public static List<CategoryResponse> ManualCategoryListResponse(List<Category> categories)
        {
            return categories
                .Select(ManualCategoryResponse)
                .ToList();
        }
    }
}