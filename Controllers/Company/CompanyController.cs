using CSMS_API.Models;
using CSMS_API.Utils;
using Magicodes.ExporterAndImporter.Excel;
using Microsoft.AspNetCore.Mvc;

namespace CSMS_API.Controllers
{
    [Route("")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyService _companyService;
        private readonly CompanyExcelService _companyExcelService;
        public CompanyController(CompanyService companyService, CompanyExcelService companyExcelService)
        {
            _companyService = companyService;
            _companyExcelService = companyExcelService;
        }
        [HttpPost("company/create")]
        public async Task<ActionResult<CompanyOnlyResponse>> CreateCompanyAsync(CreateCompanyRequest request)
        {
            var response = await _companyService.CreateCompanyAsync(request, User);
            return response;
        }
        [HttpPost("companies/excel-import")]
        public async Task<ActionResult> ImportCompaniesAsync(IFormFile file)
        {
            using var stream = file.OpenReadStream();
            await _companyExcelService.ImportCompaniesAsync(stream, User);
            return Ok("Success");
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
        [HttpGet("companies/paginated")]
        public async Task<ActionResult<Paginate<CompanyOnlyResponse>>> PaginatedCompanies(
            int pageNumber = 1,
            int pageSize = 10,
            string searchTerm = null)
        {
            var response = await _companyService.PaginatedCompanies(pageNumber, pageSize, searchTerm);
            return response;
        }
        [HttpGet("companies/paginated/with-representative")]
        public async Task<ActionResult<Paginate<CompanyWithRepresentativeResponse>>> PaginatedCompaniesWithRepresentative(
            int pageNumber = 1,
            int pageSize = 10,
            string searchTerm = null)
        {
            var response = await _companyService.PaginatedCompaniesWithRepresentative(pageNumber, pageSize, searchTerm);
            return response;
        }
        [HttpGet("companies/list")]
        public async Task<ActionResult<List<CompanyOnlyResponse>>> ListedCompanies(string? searchTerm)
        {
            var response = await _companyService.ListedCompanies(searchTerm);
            return response;
        }
        [HttpGet("companies/list/with-representative")]
        public async Task<ActionResult<List<CompanyWithRepresentativeResponse>>> ListedCompaniesWithRepresentative(string? searchTerm)
        {
            var response = await _companyService.ListedCompaniesWithRepresentative(searchTerm);
            return response;
        }
        [HttpGet("company/excel-template")]
        public async Task<ActionResult> GetTemplateAsync()
        {
            var importer = new ExcelImporter();
            var file = await importer.GenerateTemplateBytes<CompanyImportRequest>();
            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Companies.xlsx");
        }
        [HttpGet("companies/excel-export")]
        public async Task<ActionResult> ExportCompaniesAsync()
        {
            var file = await _companyExcelService.ExportCompaniesAsync();
            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Companies.xlsx");
        }

    }
}