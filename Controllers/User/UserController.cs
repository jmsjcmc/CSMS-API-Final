using CSMS_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSMS_API.Controllers
{
    [Route("")]
    [ApiController]
    public class UserController : ControllerBase, UserControllerInterface
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpPost("user/login")]
        public async Task<ActionResult<object>> UserLoginAsync(UserLoginRequest request)
        {
            var response = await _userService.UserLoginAsync(request);
            return response;
        }
        [HttpPost("user/create")]
        public async Task<ActionResult<UserWithBusinessUnitAndPositonResponse>> CreateUserAsync(CreateUserRequest request)
        {
            var response = await _userService.CreateUserAsync(request, User);
            return response;
        }
        [HttpPatch("user/{ID}/patch")]
        public async Task<ActionResult<UserWithBusinessUnitAndPositonResponse>> PatchUserByIDAsync([FromQuery] int ID, UpdateUserRequest request)
        {
            var response = await _userService.PatchUserByIDAsync(ID, request, User);
            return response;
        }
        [HttpPatch("user/{ID}/add-position")]
        public async Task<ActionResult<UserWithBusinessUnitAndPositonResponse>> AddPositionToUserByIDAsync(int ID, int positionID)
        {
            var response = await _userService.AddPositionToUserByIDAsync(ID, positionID, User);
            return response;
        }
        [HttpPatch("user/{ID}/toggle-status")]
        public async Task<ActionResult<UserOnlyResponse>> PatchUserStatusByIDAsync([FromQuery] int ID, RecordStatus status)
        {
            var response = await _userService.PatchUserStatusByIDAsync(ID, status, User);
            return response;
        }
        [HttpDelete("user/{ID}/delete")]
        public async Task<ActionResult<UserWithBusinessUnitAndPositonResponse>> DeleteUserByIDAsync([FromQuery] int ID)
        {
            var response = await _userService.DeleteUserByIDAsync(ID);
            return response;
        }
        [HttpGet("user/{ID}/get")]
        public async Task<ActionResult<UserWithBusinessUnitAndPositonResponse>> GetUserByIDAsync([FromQuery] int ID)
        {
            var response = await _userService.GetUserByIDAsync(ID);
            return response;
        }
        [HttpGet("user/authenticated-details")]
        public async Task<ActionResult<UserWithBusinessUnitAndPositonResponse>> GetAuthenticatedUserDetailsAsync()
        {
            var response = await _userService.GetAuthenticatedUserDetailsAsync(User);
            return response;
        }
        [HttpGet("users/paginated")]
        public async Task<ActionResult<Paginate<UserOnlyResponse>>> GetPaginatedUsersAsync(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? searchTerm = null,
            [FromQuery] RecordStatus? status = null)
        {
            var response = await _userService.GetPaginatedUsersAsync(pageNumber, pageSize, searchTerm, status);
            return response;
        }
        [HttpGet("users/paginated/business-unit-and-position")]
        public async Task<ActionResult<Paginate<UserWithBusinessUnitAndPositonResponse>>> GetPaginatedUsersWithBusinessUnitAndPositionAsync(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? searchTerm = null,
            [FromQuery] RecordStatus? status = null)
        {
            var response = await _userService.GetPaginatedUsersWithBusinessUnitAndPositionAsync(pageNumber, pageSize, searchTerm, status);
            return response;
        }
        [HttpGet("users/list")]
        public async Task<ActionResult<List<UserOnlyResponse>>> GetListedUsersAsync([FromQuery] string? searchTerm, [FromQuery] RecordStatus? status)
        {
            var response = await _userService.GetListedUsersAsync(searchTerm, status);
            return response;
        }
        [HttpGet("users/list/business-unit-and-position")]
        public async Task<ActionResult<List<UserWithBusinessUnitAndPositonResponse>>> GetListedUsersWithBusinessUnitAndPositionAsync([FromQuery] string? searchTerm, [FromQuery] RecordStatus? status)
        {
            var response = await _userService.GetListedUsersWithBusinessUnitAndPositionAsync(searchTerm, status);
            return response;
        }
    }
}
