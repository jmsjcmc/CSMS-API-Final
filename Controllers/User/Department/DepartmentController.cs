using CSMS_API.Models;
using CSMS_API.Utils;
using Magicodes.ExporterAndImporter.Excel;
using Microsoft.AspNetCore.Mvc;

namespace CSMS_API.Controllers
{
    [Route("")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentService _departmentService;
        private readonly DepartmentExcelService _departmentExcelService;
        public DepartmentController(DepartmentService departmentService, DepartmentExcelService departmentExcelService)
        {
            _departmentService = departmentService;
            _departmentExcelService = departmentExcelService;
        }
        [HttpPost("department/create")]
        public async Task<ActionResult<DepartmentOnlyResponse>> CreateDepartmentAsync([FromBody] string departmentName)
        {
            var response = await _departmentService.CreateDepartmentAsync(departmentName, User);
            return response;
        }
        [HttpPost("departments/excel-import")]
        public async Task<ActionResult> ImportDepartmentsAsync(IFormFile file)
        {
            using var stream = file.OpenReadStream();
            await _departmentExcelService.ImportDepartmentsAsync(stream, User);
            return Ok("Success");
        }
        [HttpPatch("department/{ID}/update")]
        public async Task<ActionResult<DepartmentOnlyResponse>> UpdateDepartmentByIDAsync(int ID, [FromBody] string departmentName)
        {
            var response = await _departmentService.UpdateDepartmentByIDAsync(ID, departmentName, User);
            return response;
        }
        [HttpDelete("department/{ID}/delete")]
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
        [HttpGet("departments/excel-template")]
        public async Task<ActionResult> GetTemplateAsync()
        {
            var importer = new ExcelImporter();
            var file = await importer.GenerateTemplateBytes<DepartmentImportRequest>();
            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Departments.xlsx");
        }
        [HttpGet("departments/excel-export")]
        public async Task<ActionResult> ExportDepartmentsAsync()
        {
            var file = await _departmentExcelService.ExportDepartmentsAsync();
            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Department.xlsx");
        }
    }
}