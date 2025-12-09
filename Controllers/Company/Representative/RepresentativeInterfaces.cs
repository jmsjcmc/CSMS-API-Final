using CSMS_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CSMS_API.Controllers
{
    public interface IRepresentativeController
    {
        Task<ActionResult<RepresentativeOnlyResponse>> CreateRepresentativeAsync(CreateRepresentativeRequest request);
        Task<ActionResult<RepresentativeOnlyResponse>> PatchRepresentativeByIDAsync(int ID, UpdateRepresentativeRequest request);
        Task<ActionResult<RepresentativeOnlyResponse>> PatchRepresentativeStatusByIDAsync(int ID, RecordStatus status);
        Task<ActionResult<RepresentativeWithCompanyResponse>> AddCompanyToRepresentativeByIDAsync(int representativeID, int companyID);
        Task<ActionResult<RepresentativeOnlyResponse>> DeleteRepresentativeByIDAsync(int ID);
        Task<ActionResult<RepresentativeOnlyResponse>> GetRepresentativeByIDAsync(int ID);
        Task<ActionResult<RepresentativeWithCompanyResponse>> GetRepresentativeWithCompanyByIDAsync(int ID);
        Task<ActionResult<Paginate<RepresentativeOnlyResponse>>> GetPaginatedRepresentativesAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? status);
        Task<ActionResult<Paginate<RepresentativeWithCompanyResponse>>> GetPaginatedRepresentativesWithCompanyAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? status);
        Task<ActionResult<List<RepresentativeOnlyResponse>>> GetListedRepresentativesAsync(string? searchTerm, RecordStatus? status);
        Task<ActionResult<List<RepresentativeWithCompanyResponse>>> GetListedRepresentativesWithCompanyAsync(string? searchTerm, RecordStatus? status);
    }
    public interface IRepresentativeService
    {
        Task<RepresentativeOnlyResponse> CreateRepresentativeAsync(CreateRepresentativeRequest request, ClaimsPrincipal user);
        Task<RepresentativeOnlyResponse> PatchRepresentativeByIDAsync(int ID, UpdateRepresentativeRequest request, ClaimsPrincipal user);
        Task<RepresentativeOnlyResponse> PatchRepresentativeStatusByIDAsync(int ID, RecordStatus status, ClaimsPrincipal user);
        Task<RepresentativeWithCompanyResponse> AddCompanyToRepresentativeByIDAsync(int representativeID, int companyID, ClaimsPrincipal user);
        Task<RepresentativeOnlyResponse> DeleteRepresentativeByIDAsync(int ID);
        Task<RepresentativeOnlyResponse> GetRepresentativeByIDAsync(int ID);
        Task<RepresentativeWithCompanyResponse> GetRepresentativeWithCompanyByIDAsync(int ID);
        Task<Paginate<RepresentativeOnlyResponse>> GetPaginatedRepresentativesAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? status);
        Task<Paginate<RepresentativeWithCompanyResponse>> GetPaginatedRepresentativesWithCompanyAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? status);
        Task<List<RepresentativeOnlyResponse>> GetListedRepresentativesAsync(string? searchTerm, RecordStatus? status);
        Task<List<RepresentativeWithCompanyResponse>> GetListedRepresentativesWithCompanyAsync(string? searchTerm, RecordStatus? status);
    }
    public interface IRepresentativeQueries
    {
        Task<Representative?> PatchRepresentativeByIDAsync(int ID);
        Task<RepresentativeOnlyResponse?> RepresentativeOnlyResponseByIDAsync(int ID);
        Task<RepresentativeWithCompanyResponse?> RepresentativeWithCompanyResponseByIDAsync(int ID);
        IQueryable<RepresentativeOnlyResponse> RepresentativeOnlyResponseAsync(string? searchTerm, RecordStatus? status);
        IQueryable<RepresentativeWithCompanyResponse> RepresentativeWithCompanyResponseAsync(string? searchTerm, RecordStatus? status);
    }
}