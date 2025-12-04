using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API.Controllers
{
    public class UserQuery : UserQueriesInterface
    {
        private readonly DB _context;
        public UserQuery(DB context)
        {
            _context = context;
        }
        public async Task<User?> PatchUserByIDAsync(int ID)
        {
            return await _context.User
                .SingleOrDefaultAsync(U => U.ID == ID);
        }
        public async Task<UserWithBusinessUnitAndPositonResponse?> UserWithBusinessUnitAndPositonResponseByIDAsync(int ID)
        {
            return await _context.User
                .AsNoTracking()
                .Where(U => U.ID == ID)
                .Select(U => new UserWithBusinessUnitAndPositonResponse
                {
                    ID = U.ID,
                    FullName = $"{U.FirstName} {U.LastName}",
                    Username = U.Username,
                    BusinessUnitID = U.BusinessUnitID,
                    BusinessUnitName = U.BusinessUnit.Name,
                    BusinessUnitLocation = U.BusinessUnit.Location,
                    PositionID = U.PositionID,
                    PositionName = U.Position.Name,
                    DepartmentID = U.Position.DepartmentID,
                    DepartmentName = U.Position.Department.Name
                }).SingleOrDefaultAsync();
        }
        public async Task<UserOnlyResponse?> UserOnlyResponseByIDAsync(int ID)
        {
            return await _context.User
                .AsNoTracking()
                .Where(U => U.ID == ID)
                .Select(U => new UserOnlyResponse
                {
                    ID = U.ID,
                    FullName = $"{U.FirstName} {U.LastName}",
                    Username = U.Username,
                    CreatedOn = U.CreatedOn,
                    RecordStatus = U.RecordStatus
                }).SingleOrDefaultAsync();
        }
        public IQueryable<UserWithBusinessUnitAndPositonResponse> UserWithBusinessUnitAndPositonResponseAsync(string? searchTerm, RecordStatus? status)
        {
            var query = _context.User
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(U => U.FirstName.Contains(searchTerm) ||
                U.LastName.Contains(searchTerm) ||
                U.Username.Contains(searchTerm));
            }
            if (status.HasValue)
            {
                query = query.Where(U => U.RecordStatus == status);
            }

            return query
                .OrderByDescending(U => U.ID)
                .Select(U => new UserWithBusinessUnitAndPositonResponse
                {
                    ID = U.ID,
                    FullName = $"{U.FirstName} {U.LastName}",
                    Username = U.Username,
                    BusinessUnitID = U.BusinessUnitID,
                    BusinessUnitName = U.BusinessUnit.Name,
                    BusinessUnitLocation = U.BusinessUnit.Location,
                    PositionID = U.PositionID,
                    PositionName = U.Position.Name,
                    DepartmentID = U.Position.DepartmentID,
                    DepartmentName = U.Position.Department.Name
                });
        }
        public IQueryable<UserOnlyResponse> UserOnlyResponseAsync(string? searchTerm, RecordStatus? status)
        {
            var query = _context.User
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(U => U.FirstName.Contains(searchTerm) ||
                U.LastName.Contains(searchTerm) ||
                U.Username.Contains(searchTerm));
            }
            if (status.HasValue)
            {
                query = query.Where(U => U.RecordStatus == status);
            }

            return query
                .OrderByDescending(U => U.ID)
                .Select(U => new UserOnlyResponse
                {
                    ID = U.ID,
                    FullName = $"{U.FirstName} {U.LastName}",
                    Username = U.Username,
                    CreatedOn = U.CreatedOn,
                    RecordStatus = U.RecordStatus
                });
        }
    }
}
