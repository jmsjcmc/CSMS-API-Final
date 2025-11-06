using CSMS_API.Models;
using CSMS_API.Utils;
using Magicodes.ExporterAndImporter.Excel;
using Microsoft.AspNetCore.Mvc;

namespace CSMS_API.Controllers
{
    [Route("")]
    [ApiController]
    public class ColdStorageController : ControllerBase
    {
        private readonly ColdStorageService _coldStorageService;
        private readonly ColdStorageExcelService _coldStorageExcelService;
        public ColdStorageController(ColdStorageService coldStorageService, ColdStorageExcelService coldStorageExcelService)
        {
            _coldStorageService = coldStorageService;
            _coldStorageExcelService = coldStorageExcelService;
        }
        [HttpPost("cold-storage/create")]
        public async Task<ActionResult<ColdStorageOnlyResponse>> CreateColdStorageAsync(string coldStorageNumber)
        {
            var response = await _coldStorageService.CreateColdStorageAsync(coldStorageNumber, User);
            return response;
        }
        [HttpPost("cold-storages/excel-import")]
        public async Task<ActionResult> ImportColdStoragesAsync(IFormFile file)
        {
            using var stream = file.OpenReadStream();
            await _coldStorageExcelService.ImportColdStoragesAsync(stream, User);
            return Ok("Success");
        }
        [HttpPatch("cold-storage/update/{ID}")]
        public async Task<ActionResult<ColdStorageOnlyResponse>> UpdateColdStorageByIDAsync(int ID, string coldStorageNumber)
        {
            var response = await _coldStorageService.UpdateColdStorageByIDAsync(ID, coldStorageNumber, User);
            return response;
        }
        [HttpDelete("cold-storage/delete/{ID}")]
        public async Task<ActionResult<ColdStorageOnlyResponse>> DeleteColdStorageByIDAsync(int ID)
        {
            var response = await _coldStorageService.DeleteColdStorageByIDAsync(ID);
            return response;
        }
        [HttpGet("cold-storage/{ID}")]
        public async Task<ActionResult<ColdStorageOnlyResponse>> GetColdStorageByIDAsync(int ID)
        {
            var response = await _coldStorageService.GetColdStorageByIDAsync(ID);
            return response;
        }
        [HttpGet("cold-storages/paginated")]
        public async Task<ActionResult<Paginate<ColdStorageOnlyResponse>>> PaginatedColdStorages(
            int pageNumber = 1,
            int pageSize = 10,
            string searchTerm = null)
        {
            var response = await _coldStorageService.PaginatedColdStorages(pageNumber, pageSize, searchTerm);
            return response;
        }
        [HttpGet("cold-storages/list")]
        public async Task<ActionResult<List<ColdStorageOnlyResponse>>> ListedColdStorages(string? searchTerm)
        {
            var response = await _coldStorageService.ListedColdStorages(searchTerm);
            return response;
        }
        [HttpGet("cold-storages/excel-template")]
        public async Task<ActionResult> GetTemplateAsync()
        {
            var importer = new ExcelImporter();
            var file = await importer.GenerateTemplateBytes<ColdStorageImportRequest>();
            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ColdStorages.xlsx");
        }
        [HttpGet("cold-storages/excel-export")]
        public async Task<ActionResult> ExportColdStoragesAsync()
        {
            var file = await _coldStorageExcelService.ExportColdStoragesAsync();
            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ColdStorages.xlsx");
        }
    }
}