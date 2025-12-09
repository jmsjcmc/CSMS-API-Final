using CSMS_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CSMS_API.Controllers
{
    public interface IDispatchingController
    {
        Task<ActionResult<DispatchingWithDispatchingPlacementResponse>> CreateDispatchingAsync(CreateDispatchingRequest request);
        Task<ActionResult<DispatchingWithDispatchingPlacementResponse>> PatchDispatchingByIDAsync(int ID, UpdateDispatchingRequest request);
        Task<ActionResult<DispatchingWithDispatchingPlacementResponse>> PatchDispatchingStatusByIDAsync(int ID, RecordStatus status);
        Task<ActionResult<DispatchingWithDispatchingPlacementResponse>> PatchDispatchingApprovalByIDAsync(int ID, ApprovalStatus status);
        Task<ActionResult<DispatchingWithDispatchingPlacementResponse>> DeleteDispatchingByIDAsync(int ID);
        Task<ActionResult<DispatchingWithDispatchingPlacementResponse>> GetDispatchingByIDAsync(int ID);
        Task<Paginate<ActionResult<DispatchingWithDispatchingPlacementResponse>>> GetPaginatedDispatchingsAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus,
            ApprovalStatus? approvalStatus);
        Task<ActionResult<List<DispatchingWithDispatchingPlacementResponse>>> GetListedDispatchingsAsync(string? searchTerm, RecordStatus? recordStatus, ApprovalStatus? approvalStatus);
    }
    public interface IDispatchingService
    {
        Task<DispatchingWithDispatchingPlacementResponse> CreateDispatchingAsync(CreateDispatchingRequest request, ClaimsPrincipal user);
        Task<DispatchingWithDispatchingPlacementResponse> PatchDispatchingByIDAsync(int ID, UpdateDispatchingRequest request, ClaimsPrincipal user);
        Task<DispatchingWithDispatchingPlacementResponse> PatchDispatchingStatusByIDAsync(int ID, RecordStatus status, ClaimsPrincipal user);
        Task<DispatchingWithDispatchingPlacementResponse> PatchDispatchingApprovalByIDAsync(int ID, ApprovalStatus status, ClaimsPrincipal user);
        Task<DispatchingWithDispatchingPlacementResponse> DeleteDispatchingByIDAsync(int ID);
        Task<DispatchingWithDispatchingPlacementResponse> GetDispatchingByIDAsync(int ID);
        Task<Paginate<DispatchingWithDispatchingPlacementResponse>> GetPaginatedDispatchingsAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            RecordStatus? recordStatus,
            ApprovalStatus? approvalStatus);
        Task<List<DispatchingWithDispatchingPlacementResponse>> GetListedDispatchingsAsync(string? searchTerm, RecordStatus? recordStatus, ApprovalStatus? approvalStatus);
    }
    public interface IDispatchingQueries
    {
        Task<Dispatching?> PatchDispatchingByIDAsync(int ID);
        Task<DispatchingWithDispatchingPlacementResponse?> DispatchingWithDispatchingPlacementResponseByIDAsync(int ID);
        IQueryable<DispatchingWithDispatchingPlacementResponse> DispatchingWithDispatchingPlacementResponseAsync(string? searchTerm, RecordStatus? recordStatus, ApprovalStatus? approvalStatus);
    }
}