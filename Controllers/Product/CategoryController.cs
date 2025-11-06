using CSMS_API.Models;
using CSMS_API.Utils;
using Magicodes.ExporterAndImporter.Excel;
using Microsoft.AspNetCore.Mvc;

namespace CSMS_API.Controllers
{
    [Route("")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        private readonly CategoryExcelService _categoryExcelService;
        public CategoryController(CategoryService categoryService, CategoryExcelService categoryExcelService)
        {
            _categoryService = categoryService;
            _categoryExcelService = categoryExcelService;
        }
        [HttpPost("category/create")]
        public async Task<ActionResult<CategoryResponse>> CreateCategoryAsync(string categoryName)
        {
            var response = await _categoryService.CreateCategoryAsync(categoryName, User);
            return response;
        }
        [HttpPost("categories/excel-import")]
        public async Task<ActionResult> ImportCategoriesAsync(IFormFile file)
        {
            using var stream = file.OpenReadStream();
            await _categoryExcelService.ImportCategoriesAsync(stream, User);
            return Ok("Success");
        }
        [HttpPatch("category/{ID}/update")]
        public async Task<ActionResult<CategoryResponse>> UpdateCategoryByIDAsync(int ID, string categoryName)
        {
            var response = await _categoryService.UpdateCategoryByIDAsync(ID, categoryName, User);
            return response;
        }
        [HttpDelete("category/{ID}/delete")]
        public async Task<ActionResult<CategoryResponse>> DeleteCategoryByIDAsync(int ID)
        {
            var response = await _categoryService.DeleteCategoryByIDAsync(ID);
            return response;
        }
        [HttpGet("category/{ID}")]
        public async Task<ActionResult<CategoryResponse>> GetCategoryByIDAsync(int ID)
        {
            var response = await _categoryService.GetCategoryByIDAsync(ID);
            return response;
        }
        [HttpGet("categories/paginated")]
        public async Task<ActionResult<Paginate<CategoryResponse>>> PaginatedCategories(
            int pageNumber = 1,
            int pageSize = 10,
            string searchTerm = null)
        {
            var response = await _categoryService.PaginatedCategories(pageNumber, pageSize, searchTerm);
            return response;
        }
        [HttpGet("categories/list")]
        public async Task<ActionResult<List<CategoryResponse>>> ListedCategories(string? searchTerm)
        {
            var response = await _categoryService.ListedCategories(searchTerm);
            return response;
        }
        [HttpGet("categories/excel-template")]
        public async Task<ActionResult> GetTemplateAsync()
        {
            var importer = new ExcelImporter();
            var file = await importer.GenerateTemplateBytes<CategoryImportRequest>();
            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Categories.xlsx");
        }
        [HttpGet("categories/excel-export")]
        public async Task<ActionResult> ExportCategoriesAsync()
        {
            var file = await _categoryExcelService.ExportCategoriesAsync();
            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Categories.xlsx");
        }
    }
}