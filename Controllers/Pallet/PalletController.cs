using CSMS_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSMS_API.Controllers
{
    [Route("")]
    [ApiController]
    public class PalletController : ControllerBase
    {
        private readonly PalletService _palletService;
        public PalletController(PalletService palletService)
        {
            _palletService = palletService;
        }
        [HttpPost("pallet/create")]
        public async Task<ActionResult<PalletOnlyResponse>> CreatePalletAsync(CreatePalletRequest request)
        {
            var response = await _palletService.CreatePalletAsync(request, User);
            return response;
        }
        [HttpPatch("pallet/update/{ID}")]
        public async Task<ActionResult<PalletOnlyResponse>> UpdatePalletByIDAsync(int ID, UpdatePalletRequest requset)
        {
            var response = await _palletService.UpdatePalletByIDAsync(ID, requset, User);
            return response;
        }
        [HttpDelete("pallet/delete/{ID}")]
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
    }
}