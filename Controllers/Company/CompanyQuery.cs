using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API.Controllers
{
    public class CompanyQuery : CompanyQueriesInterface
    {
        private readonly DB _context;
        public CompanyQuery(DB context)
        {
            _context = context;
        }
        public async Task<Company?> PatchCompanyByIDAsync(int ID)
        {
            return await _context.Company
                .SingleOrDefaultAsync(C => C.ID == ID);
        }
        public async Task<CompanyOnlyResponse?> CompanyOnlyResponseByIDAsync(int ID)
        {
            return await _context.Company
                .AsNoTracking()
                .Where(C => C.)
        }
        public async Task<CompanyWithRepresentativeResponse?> CompanyWithRepresentativeResponseByIDAsync(int ID)
        {

        }
        public IQueryable<CompanyOnlyResponse> CompanyOnlyResponseAsync(string? searchTerm, RecordStatus? status)
        {

        }
        public IQueryable<CompanyWithRepresentativeResponse> CompanyWithRepresentativeResponseAsync(string? searchTerm, RecordStatus? status)
        {

        }
    }
}