using AutoMapper;
using CSMS_API.Models;
using CSMS_API.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CSMS_API.Controllers
{
    public class UserRoleService : UserRoleServiceInterface
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
        public async Task<UserWithRoleResponse> AddRoleToUserAsync([FromQuery] int userID, [FromQuery] int roleID, ClaimsPrincipal user)
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
        public async Task<UserWithRoleResponse> PatchUserRoleStatusByIDAsync([FromQuery] int ID, RecordStatus status, ClaimsPrincipal user)
        {
            var query = await _userRoleQuery.PatchUserRoleByIDAsync(ID);

            query.RecordStatus = status;

            await _context.SaveChangesAsync();

            var userRoleLog = new UserRoleLog
            {
                UserRoleID = query.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.UserRoleLog.AddAsync(userRoleLog);
            await _context.SaveChangesAsync();

            return await _userRoleQuery.UserWithRoleResponseByIDAsync(query.ID);
        }
        public async Task<Paginate<UserWithRoleResponse>> GetPaginatedUserRolesAsync(
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            [FromQuery] int? ID,
            [FromQuery] RecordStatus? status)
        {
            var query = _userRoleQuery.UserWithRoleResponseAsync(ID, status);
            return await PaginationHelper.PaginateAndMap(query, pageNumber, pageSize);
        }
        public async Task<List<UserWithRoleResponse>> GetListedUserRolesAsync([FromQuery] int? ID, RecordStatus? status)
        {
            return await _userRoleQuery.UserWithRoleResponseAsync(ID, status).ToListAsync();
        }
    }
}