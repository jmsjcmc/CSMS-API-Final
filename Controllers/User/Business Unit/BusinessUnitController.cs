using CSMS_API.Models;
using CSMS_API.Models.Entities;
using CSMS_API.Utils;
using Magicodes.ExporterAndImporter.Excel;
using Microsoft.AspNetCore.Mvc;

namespace CSMS_API.Controllers
{
    [Route("")]
    [ApiController]
    public class BusinessUnitController : ControllerBase
    {
        private readonly BusinessUnitService _businessUnitService;
        private readonly BusinessUnitExcelService _businessUnitExcelService;
        public BusinessUnitController(BusinessUnitService businessUnitService, BusinessUnitExcelService businessUnitExcelService)
        {
            _businessUnitService = businessUnitService;
            _businessUnitExcelService = businessUnitExcelService;
        }
        [HttpPost("business-unit/create")]
        public async Task<ActionResult<BusinessUnitResponse>> CreateBusinessUnitAsync(CreateBusinessUnitRequest request)
        {
            var response = await _businessUnitService.CreateBusinessUnitAsync(request, User);
            return response;
        }
        [HttpPost("business-units/excel-import")]
        public async Task<ActionResult> ImportBusinessUnitsAsync(IFormFile file)
        {
            using var stream = file.OpenReadStream();
            await _businessUnitExcelService.ImportBusinessUnitsAsync(stream, User);
            return Ok("Success");
        }
        [HttpPatch("business-unit/{ID}/update")]
        public async Task<ActionResult<BusinessUnitResponse>> UpdateBusinessUnitByIDAsync(int ID, UpdateBusinessUnitRequest request)
        {
            var response = await _businessUnitService.UpdateBusinessUnitByIDAsync(ID, request, User);
            return response;
        }
        [HttpDelete("business-unit/{ID}/delete")]
        public async Task<ActionResult<BusinessUnitResponse>> DeleteBusinessUnitByIDAsync(int ID)
        {
            var response = await _businessUnitService.DeleteBusinessUnitByIDAsync(ID);
            return response;
        }
        [HttpGet("business-unit/{ID}")]
        public async Task<ActionResult<BusinessUnitResponse>> GetBusinessUnitByIDAsync(int ID)
        {
            var response = await _businessUnitService.GetBusinessUnitByIDAsync(ID);
            return response;
        }
        [HttpGet("business-units/paginated")]
        public async Task<ActionResult<Paginate<BusinessUnitResponse>>> PaginatedBusinessUnits(
            int pageNumber = 1,
            int pageSize = 10,
            string searchTerm = null)
        {
            var response = await _businessUnitService.PaginatedBusinessUnits(pageNumber, pageSize, searchTerm);
            return response;
        }
        [HttpGet("business-units/list")]
        public async Task<ActionResult<List<BusinessUnitResponse>>> ListedBusinessUnitsAsync(string? searchTerm)
        {
            var response = await _businessUnitService.ListedBusinessUnitsAsync(searchTerm);
            return response;
        }
        [HttpGet("business-units/excel-template")]
        public async Task<ActionResult> GetTemplateAsync()
        {
            var importer = new ExcelImporter();
            var file = await importer.GenerateTemplateBytes<BusinessUnitImportRequest>();
            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "BusinessUnits.xlsx");
        }
        [HttpGet("business-units/excel-export")]
        public async Task<ActionResult> ExportBusinessUnitsAsync()
        {
            var file = await _businessUnitExcelService.ExportBusinessUnitsAsync();
            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "BusinessUnits.xlsx");
        }
    }
}