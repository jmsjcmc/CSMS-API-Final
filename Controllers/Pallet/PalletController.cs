using CSMS_API.Models;
using CSMS_API.Utils;
using Magicodes.ExporterAndImporter.Excel;
using Microsoft.AspNetCore.Mvc;

namespace CSMS_API.Controllers
{
    [Route("")]
    [ApiController]
    public class PalletController : ControllerBase
    {
        private readonly PalletService _palletService;
        private readonly PalletExcelService _paleltExcelService;
        public PalletController(PalletService palletService, PalletExcelService palletExcelService)
        {
            _palletService = palletService;
            _paleltExcelService = palletExcelService;
        }
        [HttpPost("pallet/create")]
        public async Task<ActionResult<PalletOnlyResponse>> CreatePalletAsync(CreatePalletRequest request)
        {
            var response = await _palletService.CreatePalletAsync(request, User);
            return response;
        }
        [HttpPost("pallets/excel-import")]
        public async Task<ActionResult> ImportPalletsAsync(IFormFile file)
        {
            using var stream = file.OpenReadStream();
            await _paleltExcelService.ImportPalletsAsync(stream, User);
            return Ok("Success");
        }
        [HttpPatch("pallet/{ID}/update")]
        public async Task<ActionResult<PalletOnlyResponse>> UpdatePalletByIDAsync(int ID, UpdatePalletRequest requset)
        {
            var response = await _palletService.UpdatePalletByIDAsync(ID, requset, User);
            return response;
        }
        [HttpDelete("pallet/{ID}/delete")]
        public async Task<ActionResult<PalletOnlyResponse>> DeletePalletByIDAsync(int ID)
        {
            var response = await _palletService.DeletePalletByIDAsync(ID);
            return response;
        }
        [HttpGet("pallet/{ID}")]
        public async Task<ActionResult<PalletOnlyResponse>> GetPalletByIDAsync(int ID)
        {
            var response = await _palletService.GetPalletByIDAsync(ID);
            return response;
        }
        [HttpGet("pallets/paginated")]
        public async Task<ActionResult<Paginate<PalletOnlyResponse>>> PaginatedPallets(
            int pageNumber = 1,
            int pageSize = 10,
            string searchTerm = null)
        {
            var response = await _palletService.PaginatedPallets(pageNumber, pageSize, searchTerm);
            return response;
        }
        [HttpGet("pallets/list")]
        public async Task<ActionResult<List<PalletOnlyResponse>>> ListedPallets(string? searchTerm)
        {
            var response = await _palletService.ListedPallets(searchTerm);
            return response;
        }
        [HttpGet("pallets/excel-template")]
        public async Task<ActionResult> GetTemplateAsync()
        {
            var importer = new ExcelImporter();
            var file = await importer.GenerateTemplateBytes<PalletImportRequest>();
            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Pallets.xlsx");
        }
        [HttpGet("pallets/excel-export")]
        public async Task<ActionResult> ExportPalletsAsync()
        {
            var file = await _paleltExcelService.ExportPalletsAsync();
            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Pallets.xlsx");
        }
    }
}