using CSMS_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSMS_API.Controllers
{
    [Route("")]
    [ApiController]
    public class DispatchingPlacementController : ControllerBase
    {
        private readonly DispatchingPlacementService _dispatchingPlacementService;
        public DispatchingPlacementController(DispatchingPlacementService dispatchingPlacementService)
        {
            _dispatchingPlacementService = dispatchingPlacementService;
        }
        [HttpPatch("dispatching-placement/{ID}/approve-placement")]
        public async Task<ActionResult<DispatchingPlacementOnlyResponse>> ApproveDispatchingPlacementByIDAsync(int ID)
        {
            var response = await _dispatchingPlacementService.ApproveDispatchingPlacementByIDAsync(ID, User);
            return response;
        }
    }
}