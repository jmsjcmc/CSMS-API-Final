using CSMS_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSMS_API.Controllers
{
    [Route("")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        [HttpPost("product/create")]
        public async Task<ActionResult<ProductOnlyResponse>> CreateProductAsync(CreateProductRequest request)
        {
            var response = await _productService.CreateProductAsync(request, User);
            return response;
        }
        [HttpPatch("product/update/{ID}")]
        public async Task<ActionResult<ProductOnlyResponse>> UpdateProductByIDAsync(int ID, UpdateProductRequest request)
        {
            var response = await _productService.UpdateProductByIDAsync(ID, request, User);
            return response;
        }
        [HttpDelete("product/delete/{ID}")]
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
    }
}