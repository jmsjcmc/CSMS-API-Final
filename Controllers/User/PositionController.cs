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
        [HttpPatch("position/{ID}/update")]
        public async Task<ActionResult<PositionOnlyResponse>> UpdatePositionByIDAsync(int ID, string positionName)
        {
            var response = await _positionService.UpdatePositionByIDAsync(ID, positionName, User);
            return response;
        }
        [HttpPatch("position/{ID}/add-department")]
        public async Task<ActionResult<PositionWithDepartmentResponse>> AddDepartmentToPositionByIDAsync(int ID, int departmentID)
        {
            var response = await _positionService.AddDepartmentToPositionByIDAsync(ID, departmentID, User);
            return response;
        }
        [HttpDelete("position/{ID}/delete")]
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
        [HttpGet("positions/paginated")]
        public async Task<ActionResult<Paginate<PositionOnlyResponse>>> PaginatedPositions(
            int pageNumber = 1,
            int pageSize = 10,
            string searchTerm = null)
        {
            var response = await _positionService.PaginatedPositions(pageNumber, pageSize, searchTerm);
            return response;
        }
        [HttpGet("positions/paginated/with-department")]
        public async Task<ActionResult<Paginate<PositionWithDepartmentResponse>>> PaginatedPositionsWithDepartment(
            int pageNumber = 1,
            int pageSize = 10,
            string searchTerm = null)
        {
            var response = await _positionService.PaginatedPositionsWithDepartment(pageNumber, pageSize, searchTerm);
            return response;
        }
        [HttpGet("positions/list")]
        public async Task<ActionResult<List<PositionOnlyResponse>>> ListedPositions(string? searchTerm)
        {
            var response = await _positionService.ListedPositions(searchTerm);
            return response;
        }
        [HttpGet("positions/list/with-department")]
        public async Task<ActionResult<List<PositionWithDepartmentResponse>>> ListedPositionsWithDepartment(string? searchTerm)
        {
            var response = await _positionService.ListedPositionsWithDepartment(searchTerm);
            return response;
        }
    }
}