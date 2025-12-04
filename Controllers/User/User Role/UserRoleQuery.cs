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
        
        public IQueryable<UserWithRoleResponse> UserWithRoleResponseAsync(RecordStatus? status)
        {
            var query = _context.UserRole
                .AsNoTracking()
                .AsQueryable();

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