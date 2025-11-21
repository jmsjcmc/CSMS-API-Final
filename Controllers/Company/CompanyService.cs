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
        Task<Paginate<CompanyOnlyResponse>> PaginatedCompanies(
            int pageNumber,
            int pageSize,
            string searchTerm);
        Task<Paginate<CompanyWithRepresentativeResponse>> PaginatedCompaniesWithRepresentative(
            int pageNumber,
            int pageSize,
            string searchTerm);
        Task<List<CompanyOnlyResponse>> ListedCompanies(string searchTerm);
        Task<List<CompanyWithRepresentativeResponse>> ListedCompaniesWithRepresentative(string searchTerm);
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
            return ManualCompanyMapping.ManualCompanyOnlyResponse(company);
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
            return ManualCompanyMapping.ManualCompanyOnlyResponse(company);
        }
        public async Task<CompanyOnlyResponse> DeleteCompanyByIDAsync(int ID)
        {
            var company = await _companyQuery.PatchCompanyByIDAsync(ID);

            _context.Company.Remove(company);
            await _context.SaveChangesAsync();
            return ManualCompanyMapping.ManualCompanyOnlyResponse(company);
        }
        public async Task<CompanyOnlyResponse> GetCompanyByIDAsync(int ID)
        {
            var company = await _companyQuery.GetCompanyByIDAsync(ID);
            return ManualCompanyMapping.ManualCompanyOnlyResponse(company);
        }   
        public async Task<CompanyWithRepresentativeResponse> GetCompanyWithRepresentativeByIDAsync(int ID)
        {
            var company = await _companyQuery.GetCompanyByIDAsync(ID);
            return ManualCompanyMapping.ManualCompanyWithRepresentativeResponse(company);
        }
        public async Task<Paginate<CompanyOnlyResponse>> PaginatedCompanies(
            int pageNumber,
            int pageSize,
            string searchTerm)
        {
            var query = _companyQuery.PaginatedCompanies(searchTerm);
            return await PaginationHelper.PaginatedAndManualMapping(query, pageNumber, pageSize, ManualCompanyMapping.ManualCompanyOnlyResponse);
        }
        public async Task<Paginate<CompanyWithRepresentativeResponse>> PaginatedCompaniesWithRepresentative(
            int pageNumber,
            int pageSize,
            string searchTerm)
        {
            var query = _companyQuery.PaginatedCompaniesWithRepresentative(searchTerm);
            return await PaginationHelper.PaginatedAndManualMapping(query, pageNumber, pageSize, ManualCompanyMapping.ManualCompanyWithRepresentativeResponse);
        }
        public async Task<List<CompanyOnlyResponse>> ListedCompanies(string? searchTerm)
        {
            var companies = await _companyQuery.ListedCompanies(searchTerm);
            return ManualCompanyMapping.ManualCompanyOnlyListResponse(companies);
        }
        public async Task<List<CompanyWithRepresentativeResponse>> ListedCompaniesWithRepresentative(string? searchTerm)
        {
            var companies = await _companyQuery.ListedCompaniesWithRepresentative(searchTerm);
            return ManualCompanyMapping.ManualCompanyWithRepresentativeListResponse(companies);
        }
    }
}