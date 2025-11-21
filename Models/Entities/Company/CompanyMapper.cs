using AutoMapper;

namespace CSMS_API.Models
{
    public class CompanyMapper : Profile
    {
        public CompanyMapper()
        {
            CreateMap<CreateCompanyRequest, Company>();
            CreateMap<UpdateCompanyRequest, Company>();
        }
    }
    public class RepresentativeMapper : Profile
    {
        public RepresentativeMapper()
        {
            CreateMap<CreateRepresentativeRequest, Representative>();
            CreateMap<UpdateRepresentativeRequest, Representative>();
        }
    }
    public static class ManualCompanyMapping
    {
        public static CompanyOnlyResponse ManualCompanyOnlyResponse(Company company)
        {
            return new CompanyOnlyResponse
            {
                ID = company.ID,
                Name = company.Name,
                Location = company.Location,
                Email = company.Email,
                PhoneNumber = company.PhoneNumber,
                TelephoneNumber = company.TelephoneNumber,
                RecordStatus = company.RecordStatus,
            };
        }
        public static List<CompanyOnlyResponse> ManualCompanyOnlyListResponse(List<Company> companies)
        {
            return companies
                .Select(ManualCompanyOnlyResponse)
                .ToList();
        }
        public static CompanyWithRepresentativeResponse ManualCompanyWithRepresentativeResponse(Company company)
        {
            return new CompanyWithRepresentativeResponse
            {
                ID = company.ID,
                Name = company.Name,
                Location = company.Location,
                Email = company.Email,
                PhoneNumber = company.PhoneNumber,
                TelephoneNumber = company.TelephoneNumber,
                RecordStatus = company.RecordStatus,
                Representative = company.Representative != null
                ? ManualRepresentativeOnlyListResponse(company.Representative.ToList())
                : null
            };
        }
        public static List<CompanyWithRepresentativeResponse> ManualCompanyWithRepresentativeListResponse(List<Company> companies)
        {
            return companies
                .Select(ManualCompanyWithRepresentativeResponse)
                .ToList();
        }
        public static RepresentativeOnlyResponse ManualRepresentativeOnlyResponse(Representative representative)
        {
            return new RepresentativeOnlyResponse
            {
                ID = representative.ID,
                FullName = $"{representative.FirstName} {representative.LastName}",
                Position = representative.Position,
                Email = representative.Email,
                PhoneNumber = representative.PhoneNumber,
                TelephoneNumber = representative.TelephoneNumber,
                RecordStatus = representative.RecordStatus
            };
        }
        public static List<RepresentativeOnlyResponse> ManualRepresentativeOnlyListResponse(List<Representative> representatives)
        {
            return representatives
                .Select(ManualRepresentativeOnlyResponse)
                .ToList();
        }
        public static RepresentativeWithCompanyResponse ManualRepresentativeWithCompanyResponse(Representative representative)
        {
            return new RepresentativeWithCompanyResponse
            {
                ID = representative.ID,
                FullName = $"{representative.FirstName} {representative.LastName}",
                Position = representative.Position,
                Email = representative.Email,
                PhoneNumber = representative.PhoneNumber,
                TelephoneNumber = representative.TelephoneNumber,
                RecordStatus = representative.RecordStatus,
                CompanyName = representative.Company.Name != null
                ? representative.Company.Name
                : null,
                CompanyLocation = representative.Company.Location != null
                ? representative.Company.Location
                : null
            };
        }
        public static List<RepresentativeWithCompanyResponse> ManualRepresentativeWithCompanyListResponse(List<Representative> representatives)
        {
            return representatives
                .Select(ManualRepresentativeWithCompanyResponse)
                .ToList();
        }
    }
}