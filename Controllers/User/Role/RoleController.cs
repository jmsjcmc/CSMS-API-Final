using CSMS_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSMS_API.Controllers
{
    [Route("")]
    [ApiController]
    public class RoleController : ControllerBase, RoleControllerInterface
    {
        private readonly RoleService _roleService;
        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpPost("role/create")]
        public async Task<ActionResult<RoleOnlyResponse>> CreateRoleAsync(string roleName)
        {
            var response = await _roleService.CreateRoleAsync(roleName, User);
            return response;
        }
        [HttpPatch("role/{ID}/update")]
        public async Task<ActionResult<RoleOnlyResponse>> UpdateRoleByIDAsync(int ID, string roleName)
        {
            var response = await _roleService.UpdateRoleByIDAsync(ID, roleName, User);
            return response;
        }
        [HttpPatch("role/{ID}/toggle-status")]
        public async Task<ActionResult<RoleOnlyResponse>> UpdateRoleStatusByIDAsync(int ID)
        {
            var response = await _roleService.UpdateRoleStatusByIDAsync(ID, User);
            return response;
        }
        [HttpDelete("role/{ID}/delete")]
        public async Task<ActionResult<RoleOnlyResponse>> DeleteRoleByIDAsync(int ID)
        {
            var response = await _roleService.DeleteRoleByIDAsync(ID);
            return response;
        }
        [HttpGet("role/{ID}")]
        public async Task<ActionResult<RoleOnlyResponse>> GetRoleByIDAsync(int ID)
        {
            var response = await _roleService.GetRoleByIDAsync(ID);
            return response;
        }
        [HttpGet("roles/paginated")]
        public async Task<ActionResult<Paginate<RoleOnlyResponse>>> PaginatedRoles(
            int pageNumber = 1,
            int pageSize = 10,
            string? searchTerm = null)
        {
            var response = await _roleService.PaginatedRoles(pageNumber, pageSize, searchTerm);
            return response;
        }
        [HttpGet("roles/list")]
        public async Task<ActionResult<List<RoleOnlyResponse>>> ListedRoles(string? searchTerm)
        {
            var response = await _roleService.ListedRoles(searchTerm);
            return response;
        }
    }
}