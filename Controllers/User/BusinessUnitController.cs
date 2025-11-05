using CSMS_API.Models;
using CSMS_API.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CSMS_API.Controllers
{
    [Route("")]
    [ApiController]
    public class BusinessUnitController : ControllerBase
    {
        private readonly BusinessUnitService _businessUnitService;
        public BusinessUnitController(BusinessUnitService businessUnitService)
        {
            _businessUnitService = businessUnitService;
        }
        [HttpPost("business-unit/create")]
        public async Task<ActionResult<BusinessUnitResponse>> CreateBusinessUnitAsync(CreateBusinessUnitRequest request)
        {
            var response = await _businessUnitService.CreateBusinessUnitAsync(request, User);
            return response;
        }
        [HttpPatch("business-unit/update/{ID}")]
        public async Task<ActionResult<BusinessUnitResponse>> UpdateBusinessUnitByIDAsync(int ID, UpdateBusinessUnitRequest request)
        {
            var response = await _businessUnitService.UpdateBusinessUnitByIDAsync(ID, request, User);
            return response;
        }
        [HttpDelete("business-unit/delete/{ID}")]
        public async Task<ActionResult<BusinessUnitResponse>> DeleteBusinessUnitByIDAsync(int ID)
        {
            var response = await _businessUnitService.DeleteBusinessUnitByIDAsync(ID);
            return response;
        }
        [HttpGet("business-unit/{ID}")]
        public async Task<ActionResult<BusinessUnitResponse>> GetBusinessUnitByIDAsync(int ID)
        {
            var response = await _businessUnitService.GetBusinessUnitByIDAsync(ID);
            return response;
        }
        [HttpGet("business-units/paginated")]
        public async Task<ActionResult<Paginate<BusinessUnitResponse>>> PaginatedBusinessUnits(
            int pageNumber = 1,
            int pageSize = 10,
            string searchTerm = null)
        {
            var response = await _businessUnitService.PaginatedBusinessUnits(pageNumber, pageSize, searchTerm);
            return response;
        }
        [HttpGet("business-units/list")]
        public async Task<ActionResult<List<BusinessUnitResponse>>> ListedBusinessUnitsAsync(string? searchTerm)
        {
            var response = await _businessUnitService.ListedBusinessUnitsAsync(searchTerm);
            return response;
        }
    }
}