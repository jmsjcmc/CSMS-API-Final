using CSMS_API.Models;
using CSMS_API.Utils;
using Magicodes.ExporterAndImporter.Excel;
using Microsoft.AspNetCore.Mvc;

namespace CSMS_API.Controllers
{
    [Route("")]
    [ApiController]
    public class RepresentativeController : ControllerBase, IRepresentativeController
    {
        private readonly RepresentativeService _representativeService;
        private readonly CompanyExcelService _companyExcelService;
        public RepresentativeController(RepresentativeService representativeService, CompanyExcelService companyExcelService)
        {
            _representativeService = representativeService;
            _companyExcelService = companyExcelService;
        }
        [HttpPost("representative/create")]
        public async Task<ActionResult<RepresentativeOnlyResponse>> CreateRepresentativeAsync(CreateRepresentativeRequest request)
        {
            var response = await _representativeService.CreateRepresentativeAsync(request, User);
            return response;
        }
        [HttpPost("representative/excel-import")]
        public async Task<ActionResult> ImportRepresentativeAsync(IFormFile file)
        {
            await _companyExcelService.ImportRepresentativesAsync(file, User);
            return Ok("Success");
        }
        [HttpPatch("representative/{ID}/update")]
        public async Task<ActionResult<RepresentativeOnlyResponse>> PatchRepresentativeByIDAsync(int ID, UpdateRepresentativeRequest request)
        {
            var response = await _representativeService.PatchRepresentativeByIDAsync(ID, request, User);
            return response;
        }
        [HttpPatch("representative/{ID}/toggle-status")]
        public async Task<ActionResult<RepresentativeOnlyResponse>> PatchRepresentativeStatusByIDAsync(int ID, RecordStatus status)
        {
            var response = await _representativeService.PatchRepresentativeStatusByIDAsync(ID, status, User);
            return response;
        }
        [HttpPatch("representative/{ID}/add-company")]
        public async Task<ActionResult<RepresentativeWithCompanyResponse>> AddCompanyToRepresentativeByIDAsync(int ID, int companyID)
        {
            var response = await _representativeService.AddCompanyToRepresentativeByIDAsync(ID, companyID, User);
            return response;
        }
        [HttpDelete("representative/{ID}/delete")]
        public async Task<ActionResult<RepresentativeOnlyResponse>> DeleteRepresentativeByIDAsync(int ID)
        {
            var response = await _representativeService.DeleteRepresentativeByIDAsync(ID);
            return response;
        }
        [HttpGet("representative/{ID}")]
        public async Task<ActionResult<RepresentativeOnlyResponse>> GetRepresentativeByIDAsync(int ID)
        {
            var response = await _representativeService.GetRepresentativeByIDAsync(ID);
            return response;
        }
        [HttpGet("representative/{ID}/with-company")]
        public async Task<ActionResult<RepresentativeWithCompanyResponse>> GetRepresentativeWithCompanyByIDAsync(int ID)
        {
            var response = await _representativeService.GetRepresentativeWithCompanyByIDAsync(ID);
            return response;
        }
        [HttpGet("representatives/paginated")]
        public async Task<ActionResult<Paginate<RepresentativeOnlyResponse>>> GetPaginatedRepresentativesAsync(
            int pageNumber = 1,
            int pageSize = 10,
            string? searchTerm = null,
            RecordStatus? status = null)
        {
            var response = await _representativeService.GetPaginatedRepresentativesAsync(pageNumber, pageSize, searchTerm, status);
            return response;
        }
        [HttpGet("representatives/paginated/with-company")]
        public async Task<ActionResult<Paginate<RepresentativeWithCompanyResponse>>> GetPaginatedRepresentativesWithCompanyAsync(
            int pageNumber = 1,
            int pageSize = 10,
            string? searchTerm = null,
            RecordStatus? status = null)
        {
            var response = await _representativeService.GetPaginatedRepresentativesWithCompanyAsync(pageNumber, pageSize, searchTerm, status);
            return response;
        }
        [HttpGet("representatives/list")]
        public async Task<ActionResult<List<RepresentativeOnlyResponse>>> GetListedRepresentativesAsync(string? searchTerm, RecordStatus? status)
        {
            var response = await _representativeService.GetListedRepresentativesAsync(searchTerm, status);
            return response;
        }
        [HttpGet("representatives/list/with-company")]
        public async Task<ActionResult<List<RepresentativeWithCompanyResponse>>> GetListedRepresentativesWithCompanyAsync(string? searchTerm, RecordStatus? status)
        {
            var response = await _representativeService.GetListedRepresentativesWithCompanyAsync(searchTerm, status);
            return response;
        }
        [HttpGet("representative/excel-template")]
        public async Task<ActionResult> GetTemplateAsync()
        {
            var importer = new ExcelImporter();
            var file = await importer.GenerateTemplateBytes<RepresentativeImportRequest>();
            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Representatives.xlsx");
        }
    }
}