using CSMS_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSMS_API.Controllers
{
    [Route("")]
    [ApiController]
    public class ColdStorageController : ControllerBase
    {
        private readonly ColdStorageService _coldStorageService;
        public ColdStorageController(ColdStorageService coldStorageService)
        {
            _coldStorageService = coldStorageService;
        }
        [HttpPost("cold-storage/create")]
        public async Task<ActionResult<ColdStorageOnlyResponse>> CreateColdStorageAsync(string coldStorageNumber)
        {
            var response = await _coldStorageService.CreateColdStorageAsync(coldStorageNumber, User);
            return response;
        }
        [HttpPatch("cold-storage/update/{ID}")]
        public async Task<ActionResult<ColdStorageOnlyResponse>> UpdateColdStorageByIDAsync(int ID, string coldStorageNumber)
        {
            var response = await _coldStorageService.UpdateColdStorageByIDAsync(ID, coldStorageNumber, User);
            return response;
        }
        [HttpDelete("cold-storage/delete/{ID}")]
        public async Task<ActionResult<ColdStorageOnlyResponse>> DeleteColdStorageByIDAsync(int ID)
        {
            var response = await _coldStorageService.DeleteColdStorageByIDAsync(ID);
            return response;
        }
        [HttpGet("cold-storage/{ID}")]
        public async Task<ActionResult<ColdStorageOnlyResponse>> GetColdStorageByIDAsync(int ID)
        {
            var response = await _coldStorageService.GetColdStorageByIDAsync(ID);
            return response;
        }
        [HttpGet("cold-storages/paginated")]
        public async Task<ActionResult<Paginate<ColdStorageOnlyResponse>>> PaginatedColdStorages(
            int pageNumber = 1,
            int pageSize = 10,
            string searchTerm = null)
        {
            var response = await _coldStorageService.PaginatedColdStorages(pageNumber, pageSize, searchTerm);
            return response;
        }
        [HttpGet("cold-storages/list")]
        public async Task<ActionResult<List<ColdStorageOnlyResponse>>> ListedColdStorages(string? searchTerm)
        {
            var response = await _coldStorageService.ListedColdStorages(searchTerm);
            return response;
        }
    }
}