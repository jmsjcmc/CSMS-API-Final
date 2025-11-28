using AutoMapper;
using CSMS_API.Models;
using CSMS_API.Utils;
using System.Security.Claims;

namespace CSMS_API.Controllers
{
    public interface CategoryInterface
    {
        Task<CategoryResponse> CreateCategoryAsync(string categoryName, ClaimsPrincipal user);
        Task<CategoryResponse> UpdateCategoryByIDAsync(int ID, string categoryName, ClaimsPrincipal user);
        Task<CategoryResponse> DeleteCategoryByIDAsync(int ID);
        Task<CategoryResponse> GetCategoryByIDAsync(int ID);
        Task<Paginate<CategoryResponse>> PaginatedCategories(
            int pageNumber,
            int pageSize,
            string searchTerm);
        Task<List<CategoryResponse>> ListedCategories(string? searchTerm);
    }
    public class CategoryService : CategoryInterface
    {
        private readonly DB _context;
        private readonly IMapper _mapper;
        private readonly CategoryQuery _categoryQuery;
        public CategoryService(DB context, IMapper mapper, CategoryQuery categoryQuery)
        {
            _context = context;
            _mapper = mapper;
            _categoryQuery = categoryQuery;
        }
        public async Task<CategoryResponse> CreateCategoryAsync(string categoryName, ClaimsPrincipal user)
        {
            var category = new Category
            {
                Name = categoryName,
                RecordStatus = RecordStatus.Active,
                CreatorID = AuthenticationHelper.GetUserIDAsync(user),
                CreatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.Category.AddAsync(category);
            await _context.SaveChangesAsync();

            return _mapper.Map<CategoryResponse>(category);
        }
        public async Task<CategoryResponse> UpdateCategoryByIDAsync(int ID, string categoryName, ClaimsPrincipal user)
        {
            var category = await _categoryQuery.PatchCategoryByIDAsync(ID);
            category.Name = categoryName;

            await _context.SaveChangesAsync();

            var categoryLog = new CategoryLog
            {
                CategoryID = category.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.CategoryLog.AddAsync(categoryLog);
            await _context.SaveChangesAsync();

            return _mapper.Map<CategoryResponse>(category);
        }
        public async Task<CategoryResponse> DeleteCategoryByIDAsync(int ID)
        {
            var category = await _categoryQuery.PatchCategoryByIDAsync(ID);

            _context.Category.Remove(category);
            await _context.SaveChangesAsync();

            return _mapper.Map<CategoryResponse>(category);
        }
        public async Task<CategoryResponse> GetCategoryByIDAsync(int ID)
        {
            var category = await _categoryQuery.GetCategoryByIDAsync(ID);
            return _mapper.Map<CategoryResponse>(category);
        }
        public async Task<Paginate<CategoryResponse>> PaginatedCategories(
            int pageNumber,
            int pageSize,
            string searchTerm)
        {
            var query = _categoryQuery.PaginatedCategories(searchTerm);
            return await PaginationHelper.PaginatedAndManualMapping(query, pageNumber, pageSize, ManualCategoryMapping.ManualCategoryResponse);
        }
        public async Task<List<CategoryResponse>> ListedCategories(string? searchTerm)
        {
            var categories = await _categoryQuery.ListedCategories(searchTerm);
            return _mapper.Map<List<CategoryResponse>>(categories);
        }
    }
}