using CSMS_API.Models;
using Microsoft.EntityFrameworkCore;

namespace CSMS_API.Controllers
{
    public class UserRoleQuery : UserRoleQueriesInterface
    {
        private readonly DB _context;
        public UserRoleQuery(DB context)
        {
            _context = context;
        }
        public async Task<UserRole?> PatchUserRoleByIDAsync(int ID)
        {
            return await _context.UserRole
                .SingleOrDefaultAsync(UR => UR.ID == ID);
        }
        public async Task<UserWithRoleResponse?> UserWithRoleResponseByIDAsync(int ID)
        {
            return await _context.UserRole
                .AsNoTracking()
                .Where(UR => UR.ID == ID)
                .Select(UR => new UserWithRoleResponse
                {
                    ID = UR.ID,
                    User = new UserOnlyResponse
                    {
                        ID = UR.User.ID,
                        FullName = $"{UR.User.FirstName} {UR.User.LastName}",
                        Username = UR.User.Username,
                        CreatedOn = UR.User.CreatedOn,
                        RecordStatus = UR.User.RecordStatus
                    },
                    Role = new RoleOnlyResponse
                    {
                        ID = UR.Role.ID,
                        Name = UR.Role.Name,
                        CreatedOn = UR.Role.CreatedOn,
                        RecordStatus = UR.Role.RecordStatus
                    }
                }).SingleOrDefaultAsync();
        }
        public IQueryable<UserWithRoleResponse> UserWithRoleResponseAsync(int? ID, RecordStatus? status)
        {
            var query = _context.UserRole
                .AsNoTracking()
                .AsQueryable();
            
            if (ID.HasValue)
            {
                query = query.Where(UR => UR.RoleID == ID ||
                UR.UserID == ID);
            }
            if (status.HasValue)
            {
                query = query.Where(UR => UR.RecordStatus == status);
            }

            return query
                .OrderByDescending(UR => UR.ID)
                .Select(UR => new UserWithRoleResponse
                {
                    ID = UR.ID,
                    User = new UserOnlyResponse
                    {
                        ID = UR.User.ID,
                        FullName = $"{UR.User.FirstName} {UR.User.LastName}",
                        Username = UR.User.Username,
                        CreatedOn = UR.User.CreatedOn,
                        RecordStatus = UR.User.RecordStatus
                    },
                    Role = new RoleOnlyResponse
                    {
                        ID = UR.Role.ID,
                        Name = UR.Role.Name,
                        CreatedOn = UR.Role.CreatedOn,
                        RecordStatus = UR.Role.RecordStatus
                    }
                });
        }
    }
}