using System.Security.Claims;
using AutoMapper;
using CSMS_API.Models;
using CSMS_API.Utils;

namespace CSMS_API.Controllers
{
    public interface CompanyInterface
    {
        Task<CompanyOnlyResponse> CreateCompanyAsync(CreateCompanyRequest request, ClaimsPrincipal user);
        Task<CompanyOnlyResponse> UpdateCompanyByIDAsync(int ID, CreateCompanyRequest request, ClaimsPrincipal user);
        Task<CompanyOnlyResponse> DeleteCompanyByIDAsync(int ID);
        Task<CompanyOnlyResponse> GetCompanyByIDAsync(int ID);
        Task<CompanyWithRepresentativeResponse> GetCompanyWithRepresentativeByIDAsync(int ID);
    }
    public class CompanyService : CompanyInterface
    {
        private readonly DB _context;
        private readonly IMapper _mapper;
        private readonly CompanyQuery _companyQuery;
        public CompanyService(DB context, IMapper mapper, CompanyQuery companyQuery)
        {
            _context = context;
            _mapper = mapper;
            _companyQuery = companyQuery;
        }
        public async Task<CompanyOnlyResponse> CreateCompanyAsync(CreateCompanyRequest request, ClaimsPrincipal user)
        {
            var company = _mapper.Map<Company>(request);
            company.RecordStatus = RecordStatus.Active;
            company.CreatorID = AuthenticationHelper.GetUserIDAsync(user);
            company.CreatedOn = PresentDateTimeFetcher.FetchPresentDateTime();

            await _context.Company.AddAsync(company);
            await _context.SaveChangesAsync();

            return _mapper.Map<CompanyOnlyResponse>(company);
        }
        public async Task<CompanyOnlyResponse> UpdateCompanyByIDAsync(int ID, CreateCompanyRequest request, ClaimsPrincipal user)
        {
            var company = await _companyQuery.PatchCompanyByIDAsync(ID);
            _mapper.Map(request, company);

            await _context.SaveChangesAsync();

            var companyLog = new CompanyLog
            {
                CompanyID = company.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.CompanyLog.AddAsync(companyLog);
            await _context.SaveChangesAsync();
            return _mapper.Map<CompanyOnlyResponse>(company);
        }
        public async Task<CompanyOnlyResponse> DeleteCompanyByIDAsync(int ID)
        {
            var company = await _companyQuery.PatchCompanyByIDAsync(ID);

            _context.Company.Remove(company);
            await _context.SaveChangesAsync();
            return _mapper.Map<CompanyOnlyResponse>(company);
        }
        public async Task<CompanyOnlyResponse> GetCompanyByIDAsync(int ID)
        {
            var company = await _companyQuery.GetCompanyByIDAsync(ID);
            return _mapper.Map<CompanyOnlyResponse>(company);
        }   
        public async Task<CompanyWithRepresentativeResponse> GetCompanyWithRepresentativeByIDAsync(int ID)
        {
            var company = await _companyQuery.GetCompanyByIDAsync(ID);
            return _mapper.Map<CompanyWithRepresentativeResponse>(company);
        }
    }
}