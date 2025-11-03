using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API.Controllers
{
    public class CategoryQuery
    {
        private readonly DB _context;
        public CategoryQuery(DB context)
        {
            _context = context;
        }
        public async Task<Category?> GetCategoryByIDAsync(int ID)
        {
            if (!await _context.Category.AnyAsync(c => c.ID == ID))
            {
                throw new Exception($"Category ID {ID} not found");
            }
            else
            {
                return await _context.Category
                    .AsNoTracking()
                    .Include(c => c.Creator)
                    .SingleOrDefaultAsync(c => c.ID == ID);
            }
        }
        public async Task<Category?> PatchCategoryByIDAsync(int ID)
        {
            if (!await _context.Category.AnyAsync(c => c.ID == ID))
            {
                throw new Exception($"Category ID {ID} not found");
            }
            else
            {
                return await _context.Category
                    .SingleOrDefaultAsync(c => c.ID == ID);
            }
        }
    }
}