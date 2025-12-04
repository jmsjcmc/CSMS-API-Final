using CSMS_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CSMS_API.Controllers
{
    public interface PositionControllerInterface
    {
        Task<ActionResult<PositionOnlyResponse>> CreatePositionAsync([FromBody] string positionName);
        Task<ActionResult<PositionOnlyResponse>> PatchPositionByIDAsync([FromQuery] int ID, [FromBody] string positionName);
        Task<ActionResult<PositionWithDepartmentResponse>> AddDepartmentToPositionByIDAsync([FromQuery] int positionID, int departmentID);
        Task<ActionResult<PositionOnlyResponse>> PatchPositionStatusByIDAsync([FromQuery] int ID, RecordStatus status);
        Task<ActionResult<PositionOnlyResponse>> DeletePositionByIDAsync([FromQuery] int ID);
        Task<ActionResult<PositionWithDepartmentResponse>> GetPositionByIDAsync([FromQuery] int ID);
        Task<ActionResult<Paginate<PositionOnlyResponse>>> GetPaginatedPositionsAsync(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? searchTerm = null,
            [FromQuery] RecordStatus? status = null);
        Task<ActionResult<Paginate<PositionWithDepartmentResponse>>> GetPaginatedPositionsWithDepartmentAsync(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? searchTerm = null,
            [FromQuery] RecordStatus? status = null);
        Task<ActionResult<List<PositionOnlyResponse>>> GetListedPositionsAsync(string? searchTerm, RecordStatus? status);
        Task<ActionResult<List<PositionWithDepartmentResponse>>> GetListedPositionsWithDepartmentAsync(string? searchTerm, RecordStatus? status);
    }
    public interface PositionServiceInterface
    {
        Task<PositionOnlyResponse> CreatePositionAsync([FromBody] string positionName, ClaimsPrincipal user);
        Task<PositionOnlyResponse> PatchPositionByIDAsync([FromQuery] int ID, [FromBody] string positionName, ClaimsPrincipal user);
        Task<PositionWithDepartmentResponse> AddDepartmentToPositionByIDAsync([FromQuery] int positionID, int departmentID, ClaimsPrincipal user);
        Task<PositionOnlyResponse> PatchPositionStatusByIDAsync([FromQuery] int ID, RecordStatus status, ClaimsPrincipal user);
        Task<PositionOnlyResponse> DeletePositionByIDAsync([FromQuery] int ID);
        Task<PositionWithDepartmentResponse> GetPositionByIDAsync([FromQuery] int ID);
        Task<Paginate<PositionOnlyResponse>> GetPaginatedPositionsAsync(
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            [FromQuery] string? searchTerm,
            [FromQuery] RecordStatus? status);
        Task<Paginate<PositionWithDepartmentResponse>> GetPaginatedPositionsWithDepartmentAsync(
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            [FromQuery] string? searchTerm,
            [FromQuery] RecordStatus? status);
        Task<List<PositionOnlyResponse>> GetListedPositionsAsync([FromQuery] string? searchTerm);
        Task<List<PositionWithDepartmentResponse>> GetListedPositionsWithDepartment([FromQuery] string? searchTerm);
    }
    public interface PositionQueriesInterface
    {
        Task<Position?> PatchPositionByIDAsync(int ID);
        Task<PositionOnlyResponse?> PositionOnlyResponseByIDAsync(int ID);
        Task<PositionWithDepartmentResponse?> PositionWithDepartmentResponseByIDAsync(int ID);
        IQueryable<PositionOnlyResponse> PositionOnlyResponseAsync(string? searchTerm, RecordStatus? status);
        IQueryable<PositionWithDepartmentResponse> PositionWithDepartmentResponseAsync(string? searchTerm, RecordStatus? status);
    }
}