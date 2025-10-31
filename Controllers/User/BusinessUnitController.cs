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
        [HttpPost("busines-unit/create")]
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
    }
}