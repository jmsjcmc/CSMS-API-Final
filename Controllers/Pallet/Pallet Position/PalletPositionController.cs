using CSMS_API.Models;
using CSMS_API.Utils;
using Magicodes.ExporterAndImporter.Excel;
using Microsoft.AspNetCore.Mvc;

namespace CSMS_API.Controllers
{
    [Route("")]
    [ApiController]
    public class PalletPositionController : ControllerBase
    {
        private readonly PalletPositionService _palletPositionService;
        private readonly PalletPositionExcelService _palletPositionExcelService;
        public PalletPositionController(PalletPositionService palletPositionService, PalletPositionExcelService palletPositionExcelService)
        {
            _palletPositionService = palletPositionService;
            _palletPositionExcelService = palletPositionExcelService;
        }
        [HttpPost("pallet-position/create")]
        public async Task<ActionResult<PalletPositionOnlyResponse>> CreatePalletPositionAsync(CreatePalletPositionRequest request)
        {
            var response = await _palletPositionService.CreatePalletPositionAsync(request, User);
            return response;
        }
        [HttpPost("pallet-positions/excel-import")]
        public async Task<ActionResult> ImportPalletPositionsAsync(IFormFile file)
        {
            using var stream = file.OpenReadStream();
            await _palletPositionExcelService.ImportPalletPositionsAsync(file, User);
            return Ok("Success");
        }
        [HttpPatch("pallet-position/{ID}/add-cold-storage")]
        public async Task<ActionResult<PalletPositionWithColdStorageResponse>> AddColdStorageToPalletPositionByIDAsync(int ID, int coldStorageID)
        {
            var response = await _palletPositionService.AddColdStorageToPalletPositionByIDAsync(ID, coldStorageID, User);
            return response;
        }
        [HttpPatch("pallet-position/{ID}/update")]
        public async Task<ActionResult<PalletPositionOnlyResponse>> UpdatePalletPositionByIDAsync(int ID, UpdatePalletPositionRequest request)
        {
            var response = await _palletPositionService.UpdatePalletPositionByIDAsync(ID, request, User);
            return response;
        }
        [HttpDelete("pallet-position/{ID}/delete")]
        public async Task<ActionResult<PalletPositionOnlyResponse>> DeletePalletPositionByIDAsync(int ID)
        {
            var response = await _palletPositionService.DeletePalletPositionByIDAsync(ID);
            return response;
        }
        [HttpGet("pallet-position/{ID}")]
        public async Task<ActionResult<PalletPositionWithColdStorageResponse>> GetPalletPositionByIDAsync(int ID)
        {
            var response = await _palletPositionService.GetPalletPositionByIDAsync(ID);
            return response;
        }
        [HttpGet("pallet-positions/paginated")]
        public async Task<ActionResult<Paginate<PalletPositionOnlyResponse>>> PaginatedPalletPositions(
            int pageNumber = 1,
            int pageSize = 10,
            string searchTerm = null)
        {
            var response = await _palletPositionService.PaginatedPalletPositions(pageNumber, pageSize, searchTerm);
            return response;
        }
        [HttpGet("pallet-positions/list")]
        public async Task<ActionResult<List<PalletPositionOnlyResponse>>> ListedPalletPositions(string? searchTerm)
        {
            var response = await _palletPositionService.ListedPalletPositions(searchTerm);
            return response;
        }
        [HttpGet("pallet-positions/excel-template")]
        public async Task<ActionResult> GetTemplateAsync()
        {
            var importer = new ExcelImporter();
            var file = await importer.GenerateTemplateBytes<PalletPositionImportRequest>();
            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "PalletPositions.xlsx");
        }
        //[HttpGet("pallet-positions/excel-export")]
        //public async Task<ActionResult> ExportPalletPositionsAsync()
        //{
        //
        //}
    }
}