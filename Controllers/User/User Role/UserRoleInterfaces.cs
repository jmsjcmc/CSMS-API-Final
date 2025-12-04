using CSMS_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CSMS_API.Controllers
{
    public interface UserRoleControllerInterface
    {
        Task<ActionResult<UserWithRoleResponse>> AddRoleToUserAsync([FromQuery] int userID, [FromQuery] int roleID);
        Task<ActionResult<UserWithRoleResponse>> PatchUserRoleStatusByIDAsync([FromQuery] int ID, RecordStatus status);
        Task<ActionResult<Paginate<UserWithRoleResponse>>> GetPaginatedUserRolesAsync(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] int? ID = null,
            [FromQuery] RecordStatus? status = null);
        Task<ActionResult<List<UserWithRoleResponse>>> GetListedUserRolesAsync(
            [FromQuery] int? ID, [FromQuery] RecordStatus? status);
    }
    public interface UserRoleServiceInterface
    {
        Task<UserWithRoleResponse> AddRoleToUserAsync([FromQuery] int userID, [FromQuery] int roleID, ClaimsPrincipal user);
        Task<UserWithRoleResponse> PatchUserRoleStatusByIDAsync([FromQuery] int ID, RecordStatus status, ClaimsPrincipal user);
        Task<Paginate<UserWithRoleResponse>> GetPaginatedUserRolesAsync(
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            [FromQuery] int? ID,
            [FromQuery] RecordStatus? status);
        Task<List<UserWithRoleResponse>> GetListedUserRolesAsync(
            [FromQuery] int? ID, [FromQuery] RecordStatus? status);
    }
    public interface UserRoleQueriesInterface
    {
        Task<UserRole?> PatchUserRoleByIDAsync(int ID);
        Task<UserWithRoleResponse?> UserWithRoleResponseByIDAsync(int ID);
        IQueryable<UserWithRoleResponse> UserWithRoleResponseAsync(int? ID, RecordStatus? status);
    }
}