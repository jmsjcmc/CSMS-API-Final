using CSMS_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSMS_API.Controllers
{
    [Route("")]
    [ApiController]
    public class ReceivingDetailController : ControllerBase
    {
        private readonly ReceivingDetailService _receivingDetailService;
        public ReceivingDetailController(ReceivingDetailService receivingDetailService)
        {
            _receivingDetailService = receivingDetailService;
        }
        [HttpPost("receiving-detail/create")]
        public async Task<ActionResult<ReceivingDetailOnlyResponse>> CreateReceivingDetailAsync(CreateReceivingDetailRequest request)
        {
            var response = await _receivingDetailService.CreateReceivingDetailAsync(request, User);
            return response;
        }
        [HttpPatch("receiving-detail/{ID}/update")]
        public async Task<ActionResult<ReceivingDetailWithReceivingAndProductObjectResponse>> UpdateReceivingDetailByIDAsync(int ID, UpdateReceivingDetailRequest request)
        {
            var response = await _receivingDetailService.UpdateReceivingDetailByIDAsync(ID, request, User);
            return response;
        }
        [HttpDelete("receiving-detail/{ID}/delete")]
        public async Task<ActionResult<ReceivingDetailOnlyResponse>> DeleteReceivingDetailByIDAsync(int ID)
        {
            var response = await _receivingDetailService.DeleteReceivingDetailByIDAsync(ID);
            return response;
        }
        [HttpGet("receiving-detail/{ID}")]
        public async Task<ActionResult<ReceivingDetailWithReceivingAndProductObjectResponse>> GetReceivingDetailByIDAsync(int ID)
        {
            var response = await _receivingDetailService.GetReceivingDetailByIDAsync(ID);
            return response;
        }
    }
}