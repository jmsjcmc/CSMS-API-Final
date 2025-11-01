using AutoMapper;

namespace CSMS_API.Models
{
    public class CompanyMapper : Profile
    {
        public CompanyMapper()
        {
            CreateMap<CreateCompanyRequest, Company>();
            CreateMap<UpdateCompanyRequest, Company>();
            CreateMap<Company, CompanyOnlyResponse>();
            CreateMap<Company, CompanyWithRepresentativeResponse>()
            .ForMember(d => d.Representative, o => o.MapFrom(s => s.Representative));
        }
    }
    public class RepresentativeMapper : Profile
    {
        public RepresentativeMapper()
        {
            CreateMap<CreateRepresentativeRequest, Representative>();
            CreateMap<UpdateRepresentativeRequest, Representative>();
            CreateMap<Representative, RepresentativeOnlyResponse>();
            CreateMap<Representative, RepresentativeWithCompanyResponse>()
            .ForMember(d => d.CompanyName, o => o.MapFrom(s => s.Company.Name))
            .ForMember(d => d.CompanyLocation, o => o.MapFrom(s => s.Company.Location));
        }
    }
}