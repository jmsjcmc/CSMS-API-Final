using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CSMS_API.Controllers
{
    public class DepartmentQuery
    {
        private readonly DB _context;
        public DepartmentQuery(DB context)
        {
            _context = context;
        }
        public async Task<Department?> GetDepartmentByIDAsync(int ID)
        {
            if (!await _context.Department.AnyAsync(d => d.ID == ID))
            {
                throw new Exception($"Department ID {ID} not found");
            }
            else
            {
                return await _context.Department
                .AsNoTracking()
                .Include(d => d.Position)
                .SingleOrDefaultAsync(d => d.ID == ID);
            }
        }
        public async Task<Department?> PatchDepartmentByIDAsync(int ID)
        {
            if (!await _context.Department.AnyAsync(d => d.ID == ID))
            {
                throw new Exception($"Department ID {ID} not found");
            } else
            {
                return await _context.Department
                .SingleOrDefaultAsync(d => d.ID == ID);
            }
        }
        public IQueryable<Department?> PaginatedDepartments(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var query = _context.Department
                    .AsNoTracking()
                    .Where(d => d.Name.Contains(searchTerm))
                    .OrderByDescending(d => d.ID)
                    .AsQueryable();

                return query;
            } else
            {
                var query = _context.Department
                    .AsNoTracking()
                    .OrderByDescending(d => d.ID)
                    .AsQueryable();

                return query;
            }
        }
        public IQueryable<Department?> PaginatedDepartmentsWithPosition(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var query = _context.Department
                    .AsNoTracking()
                    .Where(d => d.Name.Contains(searchTerm))
                    .Include(d => d.Position)
                    .OrderByDescending(d => d.ID)
                    .AsQueryable();

                return query;
            }
            else
            {
                var query = _context.Department
                    .AsNoTracking()
                    .Include(d => d.Position)
                    .OrderByDescending(d => d.ID)
                    .AsQueryable();

                return query;
            }
        }
        public async Task<List<Department>> ListedDepartments(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                return await _context.Department
                    .AsNoTracking()
                    .Where(d => d.Name.Contains(searchTerm))
                    .Include(d => d.Position)
                    .OrderByDescending(d => d.ID)
                    .ToListAsync();
            }
            else
            {
                return await _context.Department
                    .AsNoTracking()
                    .Include(d => d.Position)
                    .OrderByDescending(d => d.ID)
                    .ToListAsync();
            }
        }
        public async Task<List<Department>> ListedDepartmentsWithPosition(string? searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                return await _context.Department
                    .AsNoTracking()
                    .Where(d => d.Name.Contains(searchTerm))
                    .Include(d => d.Position)
                    .OrderByDescending(d => d.ID)
                    .ToListAsync();
            }
            else
            {
                return await _context.Department
                    .AsNoTracking()
                    .Include(d => d.Position)
                    .OrderByDescending(d => d.ID)
                    .ToListAsync();
            }
        }
    }
}