using CSMS_API.Models;
using CSMS_API.Utils;
using Magicodes.ExporterAndImporter.Excel;
using Microsoft.AspNetCore.Mvc;

namespace CSMS_API.Controllers
{
    [Route("")]
    [ApiController]
    public class RepresentativeController : ControllerBase
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
        [HttpPatch("representative/update/{ID}")]
        public async Task<ActionResult<RepresentativeOnlyResponse>> UpdateRepresentativeByIDAsync(int ID, UpdateRepresentativeRequest request)
        {
            var response = await _representativeService.UpdateRepresentativeByIDAsync(ID, request, User);
            return response;
        }
        [HttpPatch("representative/add-company/{ID}")]
        public async Task<ActionResult<RepresentativeWithCompanyResponse>> AddCompanyToRepresentativeByIDAsync(int ID, int companyID)
        {
            var response = await _representativeService.AddCompanyToRepresentativeByIDAsync(ID, companyID, User);
            return response;
        }
        [HttpDelete("representative/delete/{ID}")]
        public async Task<ActionResult<RepresentativeOnlyResponse>> DeleteRepresentativeByIDAsync(int ID)
        {
            var response = await _representativeService.DeleteRepresentativeByIDAsync(ID);
            return response;
        }
        [HttpGet("representative/{ID}")]
        public async Task<ActionResult<RepresentativeWithCompanyResponse>> GetRepresentativeByIDAsync(int ID)
        {
            var response = await _representativeService.GetRepresentativeByIDAsync(ID);
            return response;
        }
        [HttpGet("representative/excel-template")]
        public async Task<ActionResult> GetTemplateAsync()
        {
            var importer = new ExcelImporter();
            var file = await importer.GenerateTemplateBytes<RepresentativeImportRequest>();
            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "RepresentativeTemplate.xlsx");
        }
    }
}