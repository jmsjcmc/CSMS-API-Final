using CSMS_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSMS_API.Controllers
{
    [Route("")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentService _departmentService;
        public DepartmentController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpPost("department/create")]
        public async Task<ActionResult<DepartmentOnlyResponse>> CreateDepartmentAsync(string departmentName)
        {
            var response = await _departmentService.CreateDepartmentAsync(departmentName, User);
            return response;
        }
        [HttpPatch("department/update/{ID}")]
        public async Task<ActionResult<DepartmentOnlyResponse>> UpdateDepartmentByIDAsync(int ID, string departmentName)
        {
            var response = await _departmentService.UpdateDepartmentByIDAsync(ID, departmentName, User);
            return response;
        }
        [HttpDelete("department/delete/{ID}")]
        public async Task<ActionResult<DepartmentOnlyResponse>> DeleteDepartmentByIDAsync(int ID)
        {
            var response = await _departmentService.DeleteDepartmentByIDAsync(ID);
            return response;
        }
        [HttpGet("department/{ID}")]
        public async Task<ActionResult<DepartmentWithPositionResponse>> GetDepartmentByIDAsync(int ID)
        {
            var response = await _departmentService.GetDepartmentByIDAsync(ID);
            return response;
        }
        [HttpGet("departments/paginated")]
        public async Task<ActionResult<Paginate<DepartmentOnlyResponse>>> PaginatedDepartments(
            int pageNumber = 1,
            int pageSize = 10,
            string searchTerm = null)
        {
            var response = await _departmentService.PaginatedDepartments(pageNumber, pageSize, searchTerm);
            return response;
        }
        [HttpGet("departments/paginated/with-position")]
        public async Task<ActionResult<Paginate<DepartmentWithPositionResponse>>> PaginatedDepartmentsWithPosition(
            int pageNumber = 1,
            int pageSize = 10,
            string searchTerm = null)
        {
            var response = await _departmentService.PaginatedDepartmentsWithPosition(pageNumber, pageSize, searchTerm);
            return response;
        }
        [HttpGet("departments/list")]
        public async Task<ActionResult<List<DepartmentOnlyResponse>>> ListedDepartments(string? searchTerm)
        {
            var response = await _departmentService.ListedDepartments(searchTerm);
            return response;
        }
        [HttpGet("departments/list/with-position")]
        public async Task<ActionResult<List<DepartmentWithPositionResponse>>> ListedDepartmentsWithPosition(string? searchTerm)
        {
            var response = await _departmentService.ListedDepartmentsWithPosition(searchTerm);
            return response;
        }
    }
}