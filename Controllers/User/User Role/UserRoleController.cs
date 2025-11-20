using CSMS_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSMS_API.Controllers
{
    [Route("")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly UserRoleService _userRoleService;
        public UserRoleController(UserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }
        [HttpPost("user-role/{ID}/add-role")]
        public async Task<ActionResult<UserWithRoleResponse>> AddRoleToUserAsync(int ID, int roleID)
        {
            var response = await _userRoleService.AddRoleToUserAsync(ID, roleID, User);
            return response;
        }
        [HttpPatch("user-role/{ID}/toggle-status")]
        public async Task<ActionResult<UserWithRoleResponse>> UpdateUserRoleStatusByIDAsync(int ID)
        {
            var response = await _userRoleService.UpdateUserRoleStatusByIDAsync(ID, User);
            return response;
        }
        [HttpGet("user-roles/paginated")]
        public async Task<ActionResult<Paginate<UserWithRoleResponse>>> PaginatedUserRoles(
            int pageNumber = 1,
            int pageSize = 10,
            int ID = 0)
        {
            var response = await _userRoleService.PaginatedUserRoles(pageNumber, pageSize, ID);
            return response;
        }
        [HttpGet("user-roles/list")]
        public async Task<ActionResult<List<UserWithRoleResponse>>> ListedUserRoles(int? ID)
        {
            var response = await _userRoleService.ListedUserRoles(ID);
            return response;
        }
    }
}