using AutoMapper;

namespace CSMS_API.Models
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<CreateProductRequest, Product>();
            CreateMap<UpdateProductRequest, Product>();
            CreateMap<Product, ProductOnlyResponse>();
            CreateMap<Product, ProductWithCategoryAndCompanyResponse>()
                .ForMember(d => d.CategoryID, o => o.MapFrom(s => s.Category.ID))
                .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category.Name))
                .ForMember(d => d.CompanyID, o => o.MapFrom(s => s.Company.ID))
                .ForMember(d => d.CompanyName, o => o.MapFrom(s => s.Company.Name))
                .ForMember(d => d.CompanyLocation, o => o.MapFrom(s => s.Company.Location))
                .ForMember(d => d.CompanyEmail, o => o.MapFrom(s => s.Company.Email))
                .ForMember(d => d.CompanyPhoneNumber, o => o.MapFrom(s => s.Company.PhoneNumber))
                .ForMember(d => d.CompanyTelephoneNumber, o => o.MapFrom(s => s.Company.TelephoneNumber));
            CreateMap<Product, ProductWIthCategoryAndCompanyObjectResponse>()
                .ForMember(d => d.Category, o => o.MapFrom(s => s.Category))
                .ForMember(d => d.Company, o => o.MapFrom(s => s.Company));
        }
    }
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, CategoryResponse>();
        }
    }
}