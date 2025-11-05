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
        public IQueryable<Product> PaginatedProducts(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var query = _context.Product
                    .AsNoTracking()
                    .Where(p => p.ProductCode.Contains(searchTerm) ||
                    p.ProductName.Contains(searchTerm))
                    .OrderByDescending(p => p.ID)
                    .AsQueryable();

                return query;
            }
            else
            {
                var query = _context.Product
                   .AsNoTracking()
                   .OrderByDescending(p => p.ID)
                   .AsQueryable();

                return query;
            }
        }
        public async Task<List<Product>> ListedProducts(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                return await _context.Product
                    .AsNoTracking()
                    .Where(p => p.ProductCode.Contains(searchTerm) ||
                    p.ProductName.Contains(searchTerm))
                    .OrderByDescending(p => p.ID)
                    .ToListAsync();
            } else
            {
                return await _context.Product
                   .AsNoTracking()
                   .OrderByDescending(p => p.ID)
                   .ToListAsync();
            }
        }
    }
}