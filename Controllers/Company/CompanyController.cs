using CSMS_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSMS_API.Controllers
{
    [Route("")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyService _companyService;
        public CompanyController(CompanyService companyService)
        {
            _companyService = companyService;
        }
        [HttpPost("company/create")]
        public async Task<ActionResult<CompanyOnlyResponse>> CreateCompanyAsync(CreateCompanyRequest request)
        {
            var response = await _companyService.CreateCompanyAsync(request, User);
            return response;
        }
        [HttpPatch("company/update/{ID}")]
        public async Task<ActionResult<CompanyOnlyResponse>> UpdateCompanyByIDAsync(int ID, CreateCompanyRequest request)
        {
            var response = await _companyService.UpdateCompanyByIDAsync(ID, request, User);
            return response;
        }
        [HttpDelete("company/delete/{ID}")]
        public async Task<ActionResult<CompanyOnlyResponse>> DeleteCompanyByIDAsync(int ID)
        {
            var response = await _companyService.DeleteCompanyByIDAsync(ID);
            return response;
        }
        [HttpGet("company/{ID}")]
        public async Task<ActionResult<CompanyOnlyResponse>> GetCompanyByIDAsync(int ID)
        {
            var response = await _companyService.GetCompanyByIDAsync(ID);
            return response;
        }
        [HttpGet("company/with-representative/{ID}")]
        public async Task<ActionResult<CompanyWithRepresentativeResponse>> GetCompanyWithRepresentativeByIDAsync(int ID)
        {
            var response = await _companyService.GetCompanyWithRepresentativeByIDAsync(ID);
            return response;
        }
    }
}