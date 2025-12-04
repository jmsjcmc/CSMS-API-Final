using CSMS_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSMS_API.Controllers
{
    [Route("")]
    [ApiController]
    public class UserRoleController : ControllerBase, UserRoleControllerInterface
    {
        private readonly UserRoleService _userRoleService;
        public UserRoleController(UserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }
        [HttpPost("user-role/{userID}/add-role")]
        public async Task<ActionResult<UserWithRoleResponse>> AddRoleToUserAsync([FromQuery] int userID, [FromQuery] int roleID)
        {
            var response = await _userRoleService.AddRoleToUserAsync(userID, roleID, User);
            return response;
        }
        [HttpPatch("user-role/{ID}/toggle-status")]
        public async Task<ActionResult<UserWithRoleResponse>> PatchUserRoleStatusByIDAsync([FromQuery] int ID, RecordStatus status)
        {
            var response = await _userRoleService.PatchUserRoleStatusByIDAsync(ID, status, User);
            return response;
        }
        [HttpGet("user-roles/paginated")]
        public async Task<ActionResult<Paginate<UserWithRoleResponse>>> GetPaginatedUserRolesAsync(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] int? ID = null,
            [FromQuery] RecordStatus? status = null)
        {
            var response = await _userRoleService.GetPaginatedUserRolesAsync(pageNumber, pageSize, ID, status);
            return response;
        }
        [HttpGet("user-roles/list")]
        public async Task<ActionResult<List<UserWithRoleResponse>>> GetListedUserRolesAsync([FromQuery] int? ID, [FromQuery] RecordStatus? status)
        {
            var response = await _userRoleService.GetListedUserRolesAsync(ID, status);
            return response;
        }
    }
}