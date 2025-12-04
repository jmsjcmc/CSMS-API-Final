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
        public async Task<ActionResult<RoleOnlyResponse>> CreateRoleAsync([FromBody] string roleName)
        {
            var response = await _roleService.CreateRoleAsync(roleName, User);
            return response;
        }
        [HttpPatch("role/{ID}/patch")]
        public async Task<ActionResult<RoleOnlyResponse>> PatchRoleByIDAsync([FromQuery] int ID,[FromBody] string roleName)
        {
            var response = await _roleService.PatchRoleByIDAsync(ID, roleName, User);
            return response;
        }
        [HttpPatch("role/{ID}/toggle-status")]
        public async Task<ActionResult<RoleOnlyResponse>> PatchRoleStatusByIDAsync([FromQuery] int ID, RecordStatus status)
        {
            var response = await _roleService.PatchRoleStatusByIDAsync(ID ,status , User);
            return response;
        }
        [HttpDelete("role/{ID}/delete")]
        public async Task<ActionResult<RoleOnlyResponse>> DeleteRoleByIDAsync([FromQuery] int ID)
        {
            var response = await _roleService.DeleteRoleByIDAsync(ID);
            return response;
        }
        [HttpGet("role/{ID}")]
        public async Task<ActionResult<RoleOnlyResponse>> GetRoleByIDAsync([FromQuery] int ID)
        {
            var response = await _roleService.GetRoleByIDAsync(ID);
            return response;
        }
        [HttpGet("roles/paginated")]
        public async Task<ActionResult<Paginate<RoleOnlyResponse>>> GetPaginatedRolesAsync(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string? searchTerm = null,
            [FromQuery] RecordStatus? status = null)
        {
            var response = await _roleService.GetPaginatedRolesAsync(pageNumber, pageSize, searchTerm, status);
            return response;
        }
        [HttpGet("roles/list")]
        public async Task<ActionResult<List<RoleOnlyResponse>>> GetListedRolesAsync([FromQuery] string? searchTerm, RecordStatus? status)
        {
            var response = await _roleService.GetListedRolesAsync(searchTerm, status);
            return response;
        }
    }
}