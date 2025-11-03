using CSMS_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSMS_API.Controllers
{
    [Route("")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost("category/create")]
        public async Task<ActionResult<CategoryResponse>> CreateCategoryAsync(string categoryName)
        {
            var response = await _categoryService.CreateCategoryAsync(categoryName, User);
            return response;
        }
        [HttpPatch("category/update/{ID}")]
        public async Task<ActionResult<CategoryResponse>> UpdateCategoryByIDAsync(int ID, string categoryName)
        {
            var response = await _categoryService.UpdateCategoryByIDAsync(ID, categoryName, User);
            return response;
        }
        [HttpDelete("category/delete/{ID}")]
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
    }
}