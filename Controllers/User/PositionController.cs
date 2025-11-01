using CSMS_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSMS_API.Controllers
{
    [Route("")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly PositionService _positionService;
        public PositionController(PositionService positionService)
        {
            _positionService = positionService;
        }
        [HttpPost("position/create")]
        public async Task<ActionResult<PositionOnlyResponse>> CreatePositionAsync(string positionName)
        {
            var response = await _positionService.CreatePositionAsync(positionName, User);
            return response;
        }
        [HttpPatch("position/update/{ID}")]
        public async Task<ActionResult<PositionOnlyResponse>> UpdatePositionByIDAsync(int ID, string positionName)
        {
            var response = await _positionService.UpdatePositionByIDAsync(ID, positionName, User);
            return response;
        }
        [HttpPatch("position/add-department/{ID}")]
        public async Task<ActionResult<PositionWithDepartmentResponse>> AddDepartmentToPositionByIDAsync(int ID, int departmentID)
        {
            var response = await _positionService.AddDepartmentToPositionByIDAsync(ID, departmentID, User);
            return response;
        }
        [HttpDelete("position/delete/{ID}")]
        public async Task<ActionResult<PositionOnlyResponse>> DeletePositionByIDAsync(int ID)
        {
            var response = await _positionService.DeletePositionByIDAsync(ID);
            return response;
        }
        [HttpGet("position/{ID}")]
        public async Task<ActionResult<PositionWithDepartmentResponse>> GetPositionByIDAsync(int ID)
        {
            var response = await _positionService.GetPositionByIDAsync(ID);
            return response;
        }
    }
}