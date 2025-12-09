using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API.Controllers
{
    public class RepresentativeQuery : RepresentativeQueriesInterface
    {
        private readonly DB _context;
        public RepresentativeQuery(DB context)
        {
            _context = context;
        }
        public async Task<Representative?> PatchRepresentativeByIDAsync(int ID)
        {
            return await _context.Representative
                .SingleOrDefaultAsync(R => R.ID == ID);
        }
        public async Task<RepresentativeOnlyResponse?> RepresentativeOnlyResponseByIDAsync(int ID)
        {
            return await _context.Representative
                .AsNoTracking()
                .Where(R => R.ID == ID)
                .Select(R => new RepresentativeOnlyResponse
                {
                    ID = R.ID,
                    FullName = $"{R.FirstName} {R.LastName}",
                    Position = R.Position,
                    Email = R.Email,
                    PhoneNumber = R.PhoneNumber,
                    TelephoneNumber = R.TelephoneNumber,
                    RecordStatus = R.RecordStatus
                }).SingleOrDefaultAsync();
        }
        public async Task<RepresentativeWithCompanyResponse?> RepresentativeWithCompanyResponseByIDAsync(int ID)
        {
            return await _context.Representative
                .AsNoTracking()
                .Where(R => R.ID == ID)
                .Select(R => new RepresentativeWithCompanyResponse
                {
                    ID = R.ID,
                    FullName = $"{R.FirstName} {R.LastName}",
                    Position = R.Position,
                    Email = R.Email,
                    PhoneNumber = R.PhoneNumber,
                    TelephoneNumber = R.TelephoneNumber,
                    RecordStatus = R.RecordStatus,
                    CompanyName = R.Company.Name,
                    CompanyLocation = R.Company.Location
                }).SingleOrDefaultAsync();
        }
        public IQueryable<RepresentativeOnlyResponse> RepresentativeOnlyResponseAsync(string? searchTerm, RecordStatus? status)
        {
            var query = _context.Representative
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(R => R.FirstName.Contains(searchTerm) ||
                R.LastName.Contains(searchTerm) ||
                R.Position.Contains(searchTerm));
            }
            if (status.HasValue)
            {
                query = query.Where(R => R.RecordStatus == status.Value);
            }

            return query
                .OrderByDescending(R => R.ID)
                .Select(R => new RepresentativeOnlyResponse
                {
                    ID = R.ID,
                    FullName = $"{R.FirstName} {R.LastName}",
                    Position = R.Position,
                    Email = R.Email,
                    PhoneNumber = R.PhoneNumber,
                    TelephoneNumber = R.TelephoneNumber,
                    RecordStatus = R.RecordStatus
                });
        }
        public IQueryable<RepresentativeWithCompanyResponse> RepresentativeWithCompanyResponseAsync(string? searchTerm, RecordStatus? status)
        {
            var query = _context.Representative
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(R => R.FirstName.Contains(searchTerm) ||
                R.LastName.Contains(searchTerm) ||
                R.Position.Contains(searchTerm));
            }
            if (status.HasValue)
            {
                query = query.Where(R => R.RecordStatus == status.Value);
            }

            return query
                .OrderByDescending(R => R.ID)
                .Select(R => new RepresentativeWithCompanyResponse
                {
                    ID = R.ID,
                    FullName = $"{R.FirstName} {R.LastName}",
                    Position = R.Position,
                    Email = R.Email,
                    PhoneNumber = R.PhoneNumber,
                    TelephoneNumber = R.TelephoneNumber,
                    RecordStatus = R.RecordStatus,
                    CompanyName = R.Company.Name,
                    CompanyLocation = R.Company.Location
                });
        }
    }
}