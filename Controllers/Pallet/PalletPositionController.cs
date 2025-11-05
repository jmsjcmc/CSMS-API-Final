using CSMS_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSMS_API.Controllers
{
    [Route("")]
    [ApiController]
    public class PalletPositionController : ControllerBase
    {
        private readonly PalletPositionService _palletPositionService;
        public PalletPositionController(PalletPositionService palletPositionService)
        {
            _palletPositionService = palletPositionService;
        }
        [HttpPost("pallet-position/create")]
        public async Task<ActionResult<PalletPositionOnlyResponse>> CreatePalletPositionAsync(CreatePalletPositionRequest request)
        {
            var response = await _palletPositionService.CreatePalletPositionAsync(request, User);
            return response;
        }
        [HttpPatch("pallet-position/add-cold-storage/{ID}")]
        public async Task<ActionResult<PalletPositionWithColdStorageResponse>> AddColdStorageToPalletPositionByIDAsync(int ID, int coldStorageID)
        {
            var response = await _palletPositionService.AddColdStorageToPalletPositionByIDAsync(ID, coldStorageID, User);
            return response;
        }
        [HttpPatch("pallet-position/update/{ID}")]
        public async Task<ActionResult<PalletPositionOnlyResponse>> UpdatePalletPositionByIDAsync(int ID, UpdatePalletPositionRequest request)
        {
            var response = await _palletPositionService.UpdatePalletPositionByIDAsync(ID, request, User);
            return response;
        }
        [HttpDelete("pallet-position/delete/{ID}")]
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
    }
}