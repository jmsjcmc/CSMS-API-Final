using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;

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
    }
}