using CSMS_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSMS_API.Controllers
{
    public interface UserControllerInterface
    {
        Task<ActionResult<object>> UserLoginAsync(UserLoginRequest request);
        Task<ActionResult<UserWithBusinessUnitAndPositonResponse>> CreateUserAsync(CreateUserRequest request);
        Task<ActionResult<UserWithBusinessUnitAndPositonResponse>> PatchUserByIDAsync([FromQuery] int ID, UpdateUserRequest request);
        Task<ActionResult<UserWithBusinessUnitAndPositonResponse>> AddPositionToUserByIDAsync([FromQuery] int ID, [FromBody] int positionID);
        Task<ActionResult<UserOnlyResponse>> PatchUserStatusByIDAsync([FromQuery] int ID, RecordStatus? status);
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
        Task<ActionResult<List<UserOnlyResponse>>> GetListedUsersAsync([FromQuery] string? searchTerm);
        Task<ActionResult<List<UserWithBusinessUnitAndPositonResponse>>> GetListedUsersWithBusinessUnitAndPositionAsync([FromQuery] string? searchTerm);
    }
    public interface UserServiceInterface
    {

    }
    public interface UserQueriesInterface
    {

    }
}