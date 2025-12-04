using CSMS_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CSMS_API.Controllers
{
    public interface RoleControllerInterface
    {
        Task<ActionResult<RoleOnlyResponse>> CreateRoleAsync([FromBody] string roleName);
        Task<ActionResult<RoleOnlyResponse>> PatchRoleByIDAsync([FromQuery] int ID, [FromBody] string roleName);
        Task<ActionResult<RoleOnlyResponse>> PatchRoleStatusByIDAsync([FromQuery] int ID, RecordStatus? status);
        Task<ActionResult<RoleOnlyResponse>> DeleteRoleByIDAsync([FromQuery] int ID);
        Task<ActionResult<RoleOnlyResponse>> GetRoleByIDAsync([FromQuery] int ID);
        Task<ActionResult<Paginate<RoleOnlyResponse>>> GetPaginatedRolesAsync(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? searchTerm = null,
            [FromQuery] RecordStatus? status = null);
        Task<ActionResult<List<RoleOnlyResponse>>> GetListedRolesAsync([FromQuery] int ID, RecordStatus? status);
    }
    public interface RoleServiceInterface
    {
        Task<RoleOnlyResponse> CreateRoleAsync([FromBody] string roleName, ClaimsPrincipal user);
        Task<RoleOnlyResponse> PatchRoleByIDAsync([FromQuery] int ID, [FromBody] string roleName, ClaimsPrincipal user);
        Task<RoleOnlyResponse> PatchRoleStatusByIDAsync([FromQuery] int ID, RecordStatus status, ClaimsPrincipal user);
        Task<RoleOnlyResponse> DeleteRoleByIDAsync([FromQuery] int ID);
        Task<RoleOnlyResponse> GetRoleByIDAsync([FromQuery] int ID);
        Task<Paginate<RoleOnlyResponse>> GetPaginatedRolesAsync(
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            [FromQuery] string? searchTerm,
            [FromQuery] RecordStatus? status);
        Task<List<RoleOnlyResponse>> GetListedRolesAsync([FromQuery] string? searchTerm, RecordStatus? status);
    }
    public interface RoleQueriesInterface
    {
        Task<Role?> PatchRoleByIDAsync(int ID);
        Task<RoleOnlyResponse?> RoleOnlyResponseByIDAsync(int ID);
        IQueryable<RoleOnlyResponse> RoleOnlyResponseAsync(string? searchTerm, RecordStatus? status);
    }
}