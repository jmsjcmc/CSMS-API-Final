using AutoMapper;
using CSMS_API.Models;
using CSMS_API.Utils;
using System.Security.Claims;

namespace CSMS_API.Controllers
{
    public interface ProductInterface
    {
        Task<ProductOnlyResponse> CreateProductAsync(CreateProductRequest request, ClaimsPrincipal user);
        Task<ProductOnlyResponse> UpdateProductByIDAsync(int ID, UpdateProductRequest request, ClaimsPrincipal user);
        Task<ProductOnlyResponse> DeleteProductByIDAsync(int ID);
        Task<ProductWithCategoryAndCompanyResponse> GetProductByIDAsync(int ID);
        Task<Paginate<ProductOnlyResponse>> PaginatedProducts(
            int pageNumber,
            int pageSize,
            string searchTerm);
        Task<List<ProductOnlyResponse>> ListedProducts(string? searchTerm);
    }
    public class ProductService : ProductInterface
    {
        private readonly DB _context;
        private readonly IMapper _mapper;
        private readonly ProductQuery _productQuery;
        public ProductService(DB context, IMapper mapper, ProductQuery productQuery)
        {
            _context = context;
            _mapper = mapper;
            _productQuery = productQuery;
        }
        public async Task<ProductOnlyResponse> CreateProductAsync(CreateProductRequest request, ClaimsPrincipal user)
        {
            var product = _mapper.Map<Product>(request);

            product.CreatorID = AuthenticationHelper.GetUserIDAsync(user);
            product.CreatedOn = PresentDateTimeFetcher.FetchPresentDateTime();
            product.RecordStatus = RecordStatus.Active;

            await _context.Product.AddAsync(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductOnlyResponse>(product);
        }
        public async Task<ProductOnlyResponse> UpdateProductByIDAsync(int ID, UpdateProductRequest request, ClaimsPrincipal user)
        {
            var product = await _productQuery.PatchProductByIDAsync(ID);
            _mapper.Map(request, product);

            await _context.SaveChangesAsync();

            var productLog = new ProductLog
            {
                ProductID = product.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.ProductLog.AddAsync(productLog);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductOnlyResponse>(product);
        }
        public async Task<ProductOnlyResponse> DeleteProductByIDAsync(int ID)
        {
            var product = await _productQuery.PatchProductByIDAsync(ID);

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductOnlyResponse>(product);
        }
        public async Task<ProductWithCategoryAndCompanyResponse> GetProductByIDAsync(int ID)
        {
            var product = await _productQuery.GetProductByIDAsync(ID);
            return _mapper.Map<ProductWithCategoryAndCompanyResponse>(product);
        }
        public async Task<Paginate<ProductOnlyResponse>> PaginatedProducts(
            int pageNumber,
            int pageSize,
            string searchTerm)
        {
            var query = _productQuery.PaginatedProducts(searchTerm);
            return await PaginationHelper.PaginatedAndManualMapping(query, pageNumber, pageSize, ManualProductMapping.ManualProductOnlyResponse);
        }
        public async Task<List<ProductOnlyResponse>> ListedProducts(string? searchTerm)
        {
            var products = await _productQuery.ListedProducts(searchTerm);
            return _mapper.Map<List<ProductOnlyResponse>>(products);
        }
    }
}