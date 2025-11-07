using CSMS_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSMS_API.Controllers
{
    [Route("")]
    [ApiController]
    public class ReceivingController : ControllerBase
    {
        private readonly ReceivingService _receivingService;
        public ReceivingController(ReceivingService receivingService)
        {
            _receivingService = receivingService;
        }
        [HttpPost("receiving/create")]
        public async Task<ActionResult<ReceivingOnlyResponse>> CreateReceivingAsync(CreateReceivingRequest request)
        {
            var response = await _receivingService.CreateReceivingAsync(request, User);
            return response;
        }
        [HttpPost("receiving/add-placement")]
        public async Task<ActionResult<ReceivingPlacementWithReceivingProductReceivingDetailPalletAndPalletPositionObjectResponse>> AddPalletAndPalletPositionToReceivingDetailByIDAsync(CreateReceivingPlacementRequest request)
        {
            var response = await _receivingService.AddPalletAndPalletPositionToReceivingDetailByIDAsync(request, User);
            return response;
        }
        [HttpPatch("receiving/{ID}/add-details")]
        public async Task<ActionResult<ReceivingWithReceivingDetailResponse>> AddReceivingDetailToReceivingByIDAsync(int ID, UpdateReceivingRequest request)
        {
            var response = await _receivingService.AddReceivingDetailToReceivingByIDAsync(ID, request, User);
            return response;
        }
        [HttpPatch("receiving/{ID}/update")]
        public async Task<ActionResult<ReceivingWithReceivingDetailResponse>> UpdateReceivingByIDAsync(int ID, UpdateReceivingRequest request)
        {
            var response = await _receivingService.UpdateReceivingByIDAsync(ID, request, User);
            return response;
        }
        [HttpPatch("receiving/{ID}/approve")]
        public async Task<ActionResult<ReceivingWithReceivingDetailResponse>> ApproveReceivingByIDAsync(int ID)
        {
            var response = await _receivingService.ApproveReceivingByIDAsync(ID, User);
            return response;
        }
        [HttpDelete("receiving/{ID}/delete")]
        public async Task<ActionResult<ReceivingOnlyResponse>> DeleteReceivingByIDAsync(int ID)
        {
            var response = await _receivingService.DeleteReceivingByIDAsync(ID);
            return response;
        }
        [HttpGet("receiving/{ID}")]
        public async Task<ActionResult<ReceivingWithReceivingDetailResponse>> GetReceivingByIDAsync(int ID)
        {
            var response = await _receivingService.GetReceivingByIDAsync(ID);
            return response;
        }
    }
}