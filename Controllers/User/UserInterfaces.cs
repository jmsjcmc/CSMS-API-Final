using CSMS_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CSMS_API.Controllers
{
    public interface UserControllerInterface
    {
        Task<ActionResult<object>> UserLoginAsync(UserLoginRequest request);
        Task<ActionResult<UserWithBusinessUnitAndPositonResponse>> CreateUserAsync(CreateUserRequest request);
        Task<ActionResult<UserWithBusinessUnitAndPositonResponse>> PatchUserByIDAsync([FromQuery] int ID, UpdateUserRequest request);
        Task<ActionResult<UserWithBusinessUnitAndPositonResponse>> AddPositionToUserByIDAsync([FromQuery] int ID, [FromBody] int positionID);
        Task<ActionResult<UserOnlyResponse>> PatchUserStatusByIDAsync([FromQuery] int ID, RecordStatus status);
        Task<ActionResult<UserWithBusinessUnitAndPositonResponse>> DeleteUserByIDAsync([FromQuery] int ID);
        Task<ActionResult<UserWithBusinessUnitAndPositonResponse>> GetUserByIDAsync([FromQuery] int iD);
        Task<ActionResult<UserWithBusinessUnitAndPositonResponse>> GetAuthenticatedUserDetailsAsync();
        Task<ActionResult<Paginate<UserOnlyResponse>>> GetPaginatedUsersAsync(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? searchTerm = null,
            [FromQuery] RecordStatus? status = null);
        Task<ActionResult<Paginate<UserWithBusinessUnitAndPositonResponse>>> GetPaginatedUsersWithBusinessUnitAndPositionAsync(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? searchTerm = null,
            [FromQuery] RecordStatus? status = null);
        Task<ActionResult<List<UserOnlyResponse>>> GetListedUsersAsync([FromQuery] string? searchTerm, [FromQuery] RecordStatus? status);
        Task<ActionResult<List<UserWithBusinessUnitAndPositonResponse>>> GetListedUsersWithBusinessUnitAndPositionAsync([FromQuery] string? searchTerm, [FromQuery] RecordStatus? status);
    }
    public interface UserServiceInterface
    {
        Task<object> UserLoginAsync(UserLoginRequest request);
        Task<UserWithBusinessUnitAndPositonResponse> CreateUserAsync(CreateUserRequest request, ClaimsPrincipal user);
        Task<UserWithBusinessUnitAndPositonResponse> PatchUserByIDAsync([FromQuery] int ID, UpdateUserRequest request, ClaimsPrincipal user);
        Task<UserWithBusinessUnitAndPositonResponse> AddPositionToUserByIDAsync([FromQuery] int ID, [FromBody] int positionID, ClaimsPrincipal user);
        Task<UserOnlyResponse> PatchUserStatusByIDAsync([FromQuery] int ID, RecordStatus status, ClaimsPrincipal user);
        Task<UserWithBusinessUnitAndPositonResponse> DeleteUserByIDAsync([FromQuery] int ID);
        Task<UserWithBusinessUnitAndPositonResponse> GetUserByIDAsync([FromQuery] int ID);
        Task<UserWithBusinessUnitAndPositonResponse> GetAuthenticatedUserDetailsAsync(ClaimsPrincipal userDetail);
        Task<Paginate<UserOnlyResponse>> GetPaginatedUsersAsync(
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            [FromQuery] string? searchTerm,
            [FromQuery] RecordStatus? status);
        Task<Paginate<UserWithBusinessUnitAndPositonResponse>> GetPaginatedUsersWithBusinessUnitAndPositionAsync(
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            [FromQuery] string? searchTerm,
            [FromQuery] RecordStatus? status);
        Task<List<UserOnlyResponse>> GetListedUsersAsync([FromQuery] string? searchTerm, [FromQuery] RecordStatus? status);
        Task<List<UserWithBusinessUnitAndPositonResponse>> GetListedUsersWithBusinessUnitAndPositionAsync([FromQuery] string? searchTerm, [FromQuery] RecordStatus? status);
    }
    public interface UserQueriesInterface
    {
        Task<User?> PatchUserByIDAsync(int ID);
        Task<UserWithBusinessUnitAndPositonResponse?> UserWithBusinessUnitAndPositonResponseByIDAsync(int ID);
        Task<UserOnlyResponse?> UserOnlyResponseByIDAsync(int ID);
        IQueryable<UserWithBusinessUnitAndPositonResponse> UserWithBusinessUnitAndPositonResponseAsync(string? searchTerm, RecordStatus? status);
        IQueryable<UserOnlyResponse> UserOnlyResponseAsync(string? searchTerm, RecordStatus? status);
    }
}