using AutoMapper;
using CSMS_API.Models;
using CSMS_API.Utils;
using System.Security.Claims;

namespace CSMS_API.Controllers
{
    public interface UserRoleInterface
    {
        Task<UserWithRoleResponse> AddRoleToUserAsync(int userID, int roleID, ClaimsPrincipal user);
        Task<UserWithRoleResponse> UpdateUserRoleStatusByIDAsync(int ID, ClaimsPrincipal user);
        Task<Paginate<UserWithRoleResponse>> PaginatedUserRoles(
            int pageNumber,
            int pageSize,
            int ID);
        Task<List<UserWithRoleResponse>> ListedUserRoles(int? ID);
    }
    public class UserRoleService : UserRoleInterface
    {
        private readonly DB _context;
        private readonly IMapper _mapper;
        private readonly UserRoleQuery _userRoleQuery;
        public UserRoleService(DB context, IMapper mapper, UserRoleQuery userRoleQuery)
        {
            _context = context;
            _mapper = mapper;
            _userRoleQuery = userRoleQuery;
        }
        public async Task<UserWithRoleResponse> AddRoleToUserAsync(int userID, int roleID, ClaimsPrincipal user)
        {
            var userRole = new UserRole
            {
                UserID = userID,
                RoleID = roleID,
                AssignerID = AuthenticationHelper.GetUserIDAsync(user),
                AssignedOn = PresentDateTimeFetcher.FetchPresentDateTime(),
                RecordStatus = RecordStatus.Active
            };

            await _context.UserRole.AddAsync(userRole);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserWithRoleResponse>(userRole);
        }
        public async Task<UserWithRoleResponse> UpdateUserRoleStatusByIDAsync(int ID, ClaimsPrincipal user)
        {
            var userRole = await _userRoleQuery.PatchUserRoleByIDAsync(ID);
            userRole.RecordStatus = userRole.RecordStatus == RecordStatus.Active
                ? RecordStatus.Inactive
                : RecordStatus.Active;

            await _context.SaveChangesAsync();

            var userRoleLog = new UserRoleLog
            {
                UserRoleID = userRole.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.UserRoleLog.AddAsync(userRoleLog);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserWithRoleResponse>(userRole);
        }
        public async Task<Paginate<UserWithRoleResponse>> PaginatedUserRoles(
            int pageNumber,
            int pageSize,
            int ID)
        {
            var query = _userRoleQuery.PaginatedUserRoles(ID);
            return await PaginationHelper.PaginatedAndManualMapping(query, pageNumber, pageSize, ManualUserRoleMapping.ManualUserWithRoleResponse);
        }
        public async Task<List<UserWithRoleResponse>> ListedUserRoles(int? ID)
        {
            var userRoles = await _userRoleQuery.ListedUserRoles(ID);
            return _mapper.Map<List<UserWithRoleResponse>>(userRoles);
        }
    }
}