using CSMS_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSMS_API.Controllers
{
    [Route("")]
    [ApiController]
    public class DispatchingController : ControllerBase
    {
        private readonly DispatchingService _dispatchingService;
        public DispatchingController(DispatchingService dispatchingService)
        {
            _dispatchingService = dispatchingService;
        }
        [HttpPost("dispatching/create")]
        public async Task<ActionResult<DispatchingWithDispatchingPlacementResponse>> CreateDispatchingAsync(CreateDispatchingRequest request)
        {
            var response = await _dispatchingService.CreateDispatchingAsync(request, User);
            return response;
        }
        [HttpPatch("dispatching/{ID}/update")]
        public async Task<ActionResult<DispatchingWithDispatchingPlacementResponse>> UpdateDispatchingByIDAsync(int ID, UpdateDispatchingRequest request)
        {
            var response = await _dispatchingService.UpdateDispatchingByIDAsync(ID, request, User);
            return response;
        }
        [HttpPatch("dispatching/{ID}/approve-dispatching")]
        public async Task<ActionResult<DispatchingWithDispatchingPlacementResponse>> ApproveDispatchingByIDAsync(int ID)
        {
            var response = await _dispatchingService.ApproveDispatchingByIDAsync(ID, User);
            return response;
        }
        [HttpPatch("dispatching/{ID}/decline-dispatching")]
        public async Task<ActionResult<DispatchingWithDispatchingPlacementResponse>> DeclineDispatchingByIDAsync(int ID, string note)
        {
            var response = await _dispatchingService.DeclineDispatchingByIDAsync(ID, note, User);
            return response;
        }
        [HttpDelete("dispatching/{ID}/delete")]
        public async Task<ActionResult<DispatchingWithDispatchingPlacementResponse>> DeleteDispatchingByIDAsync(int ID)
        {
            var response = await _dispatchingService.DeleteDispatchingByIDAsync(ID);
            return response;
        }
        [HttpGet("dispatching/{ID}")]
        public async Task<ActionResult<DispatchingWithDispatchingPlacementResponse>> GetDispatchingByIDAsync(int ID)
        {
            var response = await _dispatchingService.GetDispatchingByIDAsync(ID);
            return response;
        }
    }
}