using System.Security.Claims;
using AutoMapper;
using CSMS_API.Models;
using CSMS_API.Utils;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API.Controllers
{
    public class CompanyService : ICompanyService
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
            if (await _context.Company.AnyAsync(C => C.Name == request.Name))
                throw new Exception($"{request.Name} ALREADY EXIST.");

            var company = _mapper.Map<Company>(request);

            company.RecordStatus = RecordStatus.Active;
            company.CreatorID = AuthenticationHelper.GetUserIDAsync(user);
            company.CreatedOn = PresentDateTimeFetcher.FetchPresentDateTime();

            await _context.Company.AddAsync(company);
            await _context.SaveChangesAsync();

            return await _companyQuery.CompanyOnlyResponseByIDAsync(company.ID);
        }
        public async Task<CompanyOnlyResponse> PatchCompanyByIDAsync(int ID, CreateCompanyRequest request, ClaimsPrincipal user)
        {
            var query = await _companyQuery.PatchCompanyByIDAsync(ID);

            _mapper.Map(request, query);

            await _context.SaveChangesAsync();

            var companyLog = new CompanyLog
            {
                CompanyID = query.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.CompanyLog.AddAsync(companyLog);
            await _context.SaveChangesAsync();

            return await _companyQuery.CompanyOnlyResponseByIDAsync(query.ID);
        }
        public async Task<CompanyOnlyResponse> PatchCompanyStatusByIDAsync(int ID, RecordStatus status, ClaimsPrincipal user)
        {
            var query = await _companyQuery.PatchCompanyByIDAsync(ID);

            query.RecordStatus = status;

            await _context.SaveChangesAsync();

            var companyLog = new CompanyLog
            {
                CompanyID = query.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.CompanyLog.AddAsync(companyLog);
            await _context.SaveChangesAsync();

            return await _companyQuery.CompanyOnlyResponseByIDAsync(query.ID);
        }
        public async Task<CompanyOnlyResponse> DeleteCompanyByIDAsync(int ID)
        {
            var query = await _companyQuery.PatchCompanyByIDAsync(ID);

            _context.Company.Remove(query);
            await _context.SaveChangesAsync();

            return await _companyQuery.CompanyOnlyResponseByIDAsync(query.ID);
        }
        public async Task<CompanyOnlyResponse> GetCompanyByIDAsync(int ID)
        {
            return await _companyQuery.CompanyOnlyResponseByIDAsync(ID);
        }
        public async Task<CompanyWithRepresentativeResponse> GetCompanyWithRepresentativeByIDAsync(int ID)
        {
            return await _companyQuery.CompanyWithRepresentativeResponseByIDAsync(ID);
        }
        public async Task<Paginate<CompanyOnlyResponse>> GetPaginatedCompaniesAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? status)
        {
            var query = _companyQuery.CompanyOnlyResponseAsync(searchTerm, status);

            return await PaginationHelper.PaginateAndMap(query, pageNumber, pageSize);
        }
        public async Task<Paginate<CompanyWithRepresentativeResponse>> GetPaginatedCompaniesWithRepresentativeAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? status)
        {
            var query = _companyQuery.CompanyWithRepresentativeResponseAsync(searchTerm, status);

            return await PaginationHelper.PaginateAndMap(query, pageNumber, pageSize);
        }
        public async Task<List<CompanyOnlyResponse>> GetListedCompaniesAsync(string? searchTerm, RecordStatus? status)
        {
            return await _companyQuery.CompanyOnlyResponseAsync(searchTerm, status).ToListAsync();
        }
        public async Task<List<CompanyWithRepresentativeResponse>> GetListedCompaniesWithRepresentativeAsync(string? searchTerm, RecordStatus? status)
        {
            return await _companyQuery.CompanyWithRepresentativeResponseAsync(searchTerm, status).ToListAsync();
        }
    }
}