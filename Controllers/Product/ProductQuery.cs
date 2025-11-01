using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API.Controllers
{
    public class ProductQuery
    {
        private readonly DB _context;
        public ProductQuery(DB context)
        {
            _context = context;
        }
        public async Task<Product?> GetProductByIDAsync(int ID)
        {
            if (!await _context.Product.AnyAsync(p => p.ID == ID))
            {
                throw new Exception($"Product with ID {ID} does not exist");
            }
            else
            {
                return await _context.Product
                .AsNoTracking()
                .Include(p => p.Company)
                .Include(p => p.Category)
                .SingleOrDefaultAsync(p => p.ID == ID);
            }
        }
        public async Task<Product?> PatchProductByIDAsync(int ID)
        {
            if (!await _context.Product.AnyAsync(p => p.ID == ID))
            {
                throw new Exception($"Product with ID {ID} does not exist");
            }
            else
            {
                return await _context.Product
                .SingleOrDefaultAsync(p => p.ID == ID);
            }
        }
    }
}