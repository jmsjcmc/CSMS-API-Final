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
                .Where(C => C.ID == ID)
                .Select(C => new CompanyOnlyResponse
                {
                    ID = C.ID,
                    Name = C.Name,
                    Location = C.Location,
                    Email = C.Email,
                    PhoneNumber = C.PhoneNumber,
                    TelephoneNumber = C.TelephoneNumber,
                    RecordStatus = C.RecordStatus
                }).SingleOrDefaultAsync();
        }
        public async Task<CompanyWithRepresentativeResponse?> CompanyWithRepresentativeResponseByIDAsync(int ID)
        {
            return await _context.Company
                .AsNoTracking()
                .Where(C => C.ID == ID)
                .Select(C => new CompanyWithRepresentativeResponse
                {
                    ID = C.ID,
                    Name = C.Name,
                    Location = C.Location,
                    Email = C.Email,
                    PhoneNumber = C.PhoneNumber,
                    TelephoneNumber = C.TelephoneNumber,
                    RecordStatus = C.RecordStatus,
                    Representative = C.Representative.Select(R => new RepresentativeOnlyResponse
                    {
                        ID = R.ID,
                        FullName = $"{R.FirstName} {R.LastName}",
                        Position = R.Position,
                        Email = R.Email,
                        PhoneNumber = R.PhoneNumber,
                        TelephoneNumber = R.TelephoneNumber,
                        RecordStatus = R.RecordStatus
                    }).ToList()
                }).SingleOrDefaultAsync();
        }
        public IQueryable<CompanyOnlyResponse> CompanyOnlyResponseAsync(string? searchTerm, RecordStatus? status)
        {
            var query = _context.Company
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(C => C.Name.Contains(searchTerm) ||
                C.Location.Contains(searchTerm));
            }
            if (status.HasValue)
            {
                query = query.Where(C => C.RecordStatus == status.Value);
            }

            return query
                .OrderByDescending(C => C.ID)
                .Select(C => new CompanyOnlyResponse
                {
                    ID = C.ID,
                    Name = C.Name,
                    Location = C.Location,
                    Email = C.Email,
                    PhoneNumber = C.PhoneNumber,
                    TelephoneNumber = C.TelephoneNumber,
                    RecordStatus = C.RecordStatus
                });
        }
        public IQueryable<CompanyWithRepresentativeResponse> CompanyWithRepresentativeResponseAsync(string? searchTerm, RecordStatus? status)
        {
            var query = _context.Company
               .AsNoTracking()
               .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(C => C.Name.Contains(searchTerm) ||
                C.Location.Contains(searchTerm));
            }
            if (status.HasValue)
            {
                query = query.Where(C => C.RecordStatus == status.Value);
            }

            return query
                .OrderByDescending(C => C.ID)
                .Select(C => new CompanyWithRepresentativeResponse
                {
                    ID = C.ID,
                    Name = C.Name,
                    Location = C.Location,
                    Email = C.Email,
                    PhoneNumber = C.PhoneNumber,
                    TelephoneNumber = C.TelephoneNumber,
                    RecordStatus = C.RecordStatus,
                    Representative = C.Representative.Select(R => new RepresentativeOnlyResponse
                    {
                        ID = R.ID,
                        FullName = $"{R.FirstName} {R.LastName}",
                        Position = R.Position,
                        Email = R.Email,
                        PhoneNumber = R.PhoneNumber,
                        TelephoneNumber = R.TelephoneNumber,
                        RecordStatus = R.RecordStatus
                    }).ToList()
                });
        }
    }
}