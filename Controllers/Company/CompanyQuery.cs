using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API.Controllers
{
    public class CompanyQuery
    {
        private readonly DB _context;
        public CompanyQuery(DB context)
        {
            _context = context;
        }
        public async Task<Company?> GetCompanyByIDAsync(int ID)
        {
            if (!await _context.Company.AnyAsync(c => c.ID == ID))
            {
                throw new Exception($"Company ID {ID} not found");
            }
            else
            {
                return await _context.Company
                .AsNoTracking()
                .Include(c => c.Representative)
                .SingleOrDefaultAsync(c => c.ID == ID);
            }
        }
        public async Task<Company?> PatchCompanyByIDAsync(int ID)
        {
            if (!await _context.Company.AnyAsync(c => c.ID == ID))
            {
                throw new Exception($"Company ID {ID} not found");
            }
            else
            {
                return await _context.Company
                .SingleOrDefaultAsync(c => c.ID == ID);
            }
        }
        public IQueryable<Company?> PaginatedCompanies(string searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var query = _context.Company
                    .AsNoTracking()
                    .Where(c => c.Name.Contains(searchTerm))
                    .OrderByDescending(c => c.ID)
                    .AsQueryable();

                return query;
            } else
            {
                var query = _context.Company
                    .AsNoTracking()
                    .OrderByDescending(c => c.ID)
                    .AsQueryable();

                return query;
            }
        }
        public IQueryable<Company?> PaginatedCompaniesWithRepresentative(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var query = _context.Company
                    .AsNoTracking()
                    .Where(c => c.Name.Contains(searchTerm))
                    .Include(c => c.Representative)
                    .OrderByDescending(c => c.ID)
                    .AsQueryable();

                return query;
            }
            else
            {
                var query = _context.Company
                    .AsNoTracking()
                    .Include(c => c.Representative)
                    .OrderByDescending(c => c.ID)
                    .AsQueryable();

                return query;
            }
        }
        public async Task<List<Company>> ListedCompanies(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                return await _context.Company
                    .AsNoTracking()
                    .Where(c => c.Name.Contains(searchTerm))
                    .OrderByDescending(c => c.ID)
                    .ToListAsync();
            }
            else
            {
                return await _context.Company
                     .AsNoTracking()
                     .OrderByDescending(c => c.ID)
                     .ToListAsync();
            }
        }
        public async Task<List<Company>> ListedCompaniesWithRepresentative(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                return await _context.Company
                    .AsNoTracking()
                    .Where(c => c.Name.Contains(searchTerm))
                    .Include(c => c.Representative)
                    .OrderByDescending(c => c.ID)
                    .ToListAsync();
            }
            else
            {
                return await _context.Company
                     .AsNoTracking()
                     .Include(c => c.Representative)
                     .OrderByDescending(c => c.ID)
                     .ToListAsync();
            }
        }
    }
}