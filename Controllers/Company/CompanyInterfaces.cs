using CSMS_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CSMS_API.Controllers
{
    public interface CompanyControllerInterface
    {
        Task<ActionResult<CompanyOnlyResponse>> CreateCompanyAsync(CreateCompanyRequest request);
        Task<ActionResult<CompanyOnlyResponse>> PatchCompanyByIDAsync(int ID, CreateCompanyRequest request);
        Task<ActionResult<CompanyOnlyResponse>> PatchCompanyStatusByIDAsync(int ID, RecordStatus status);
        Task<ActionResult<CompanyOnlyResponse>> DeleteCompanyByIDAsync(int ID);
        Task<ActionResult<CompanyOnlyResponse>> GetCompanyByIDAsync(int ID);
        Task<ActionResult<CompanyWithRepresentativeResponse>> GetCompanyWithRepresentativeByIDAsync(int ID);
        Task<ActionResult<Paginate<CompanyOnlyResponse>>> GetPaginatedCompaniesAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? status);
        Task<ActionResult<Paginate<CompanyWithRepresentativeResponse>>> GetPaginatedCompaniesWithRepresentativeAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? status);
        Task<ActionResult<List<CompanyOnlyResponse>>> GetListedCompaniesAsync(string? searchTerm, RecordStatus? status);
        Task<ActionResult<List<CompanyWithRepresentativeResponse>>> GetListedCompaniesWithRepresentativeAsync(string? searchTerm, RecordStatus? status);
    }
    public interface CompanyServiceInterface
    {
        Task<CompanyOnlyResponse> CreateCompanyAsync(CreateCompanyRequest request, ClaimsPrincipal user);
        Task<CompanyOnlyResponse> PatchCompanyByIDAsync(int ID, CreateCompanyRequest request, ClaimsPrincipal user);
        Task<CompanyOnlyResponse> PatchCompanyStatusByIDAsync(int ID, RecordStatus status, ClaimsPrincipal user);
        Task<CompanyOnlyResponse> DeleteCompanyByIDAsync(int ID);
        Task<CompanyOnlyResponse> GetCompanyByIDAsync(int ID);
        Task<CompanyWithRepresentativeResponse> GetCompanyWithRepresentativeByIDAsync(int ID);
        Task<Paginate<CompanyOnlyResponse>> GetPaginatedCompaniesAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? status);
        Task<Paginate<CompanyWithRepresentativeResponse>> GetPaginatedCompaniesWithRepresentativeAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? status);
        Task<List<CompanyOnlyResponse>> GetListedCompaniesAsync(string? searchTerm, RecordStatus? status);
        Task<List<CompanyWithRepresentativeResponse>> GetListedCompaniesWithRepresentativeAsync(string? searchTerm, RecordStatus? status);
    }
    public interface CompanyQueriesInterface
    {
        Task<Company?> PatchCompanyByIDAsync(int ID);
        Task<CompanyOnlyResponse?> CompanyOnlyResponseByIDAsync(int ID);
        Task<CompanyWithRepresentativeResponse?> CompanyWithRepresentativeResponseByIDAsync(int ID);
        IQueryable<CompanyOnlyResponse> CompanyOnlyResponseAsync(string? searchTerm, RecordStatus? status);
        IQueryable<CompanyWithRepresentativeResponse> CompanyWithRepresentativeResponseAsync(string? searchTerm, RecordStatus? status);
    }
}