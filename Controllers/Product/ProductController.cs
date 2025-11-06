using CSMS_API.Models;
using CSMS_API.Utils;
using Magicodes.ExporterAndImporter.Excel;
using Microsoft.AspNetCore.Mvc;

namespace CSMS_API.Controllers
{
    [Route("")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly ProductExcelService _productExcelService;
        public ProductController(ProductService productService, ProductExcelService productExcelService)
        {
            _productService = productService;
            _productExcelService = productExcelService;
        }
        [HttpPost("product/create")]
        public async Task<ActionResult<ProductOnlyResponse>> CreateProductAsync(CreateProductRequest request)
        {
            var response = await _productService.CreateProductAsync(request, User);
            return response;
        }
        [HttpPost("products/excel-import")]
        public async Task<ActionResult> ImportProductsAsync(IFormFile file)
        {
            using var stream = file.OpenReadStream();
            await _productExcelService.ImportProductsAsync(file, User);
            return Ok("Success");
        }
        [HttpPatch("product/{ID}/update")]
        public async Task<ActionResult<ProductOnlyResponse>> UpdateProductByIDAsync(int ID, UpdateProductRequest request)
        {
            var response = await _productService.UpdateProductByIDAsync(ID, request, User);
            return response;
        }
        [HttpDelete("product/{ID}/delete")]
        public async Task<ActionResult<ProductOnlyResponse>> DeleteProductByIDAsync(int ID)
        {
            var response = await _productService.DeleteProductByIDAsync(ID);
            return response;
        }
        [HttpGet("product/{ID}")]
        public async Task<ActionResult<ProductWithCategoryAndCompanyResponse>> GetProductByIDAsync(int ID)
        {
            var response = await _productService.GetProductByIDAsync(ID);
            return response;
        }
        [HttpGet("products/paginated")]
        public async Task<ActionResult<Paginate<ProductOnlyResponse>>> PaginatedProducts(
            int pageNumber = 1,
            int pageSize = 10,
            string searchTerm = null)
        {
            var response = await _productService.PaginatedProducts(pageNumber, pageSize, searchTerm);
            return response;
        }
        [HttpGet("products/list")]
        public async Task<ActionResult<List<ProductOnlyResponse>>> ListedProducts(string? searchTerm)
        {
            var response = await _productService.ListedProducts(searchTerm);
            return response;
        }
        [HttpGet("product/excel-template")]
        public async Task<ActionResult> GetTemplateAsync()
        {
            var importer = new ExcelImporter();
            var file = await importer.GenerateTemplateBytes<ProductImportRequest>();
            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Product.xlsx");
        }
    }
}