using AutoMapper;
using CSMS_API.Models;
using CSMS_API.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CSMS_API.Controllers
{
    public class RoleService : RoleServiceInterface
    {
        private readonly DB _context;
        private readonly IMapper _mapper;
        private readonly RoleQuery _roleQuery;
        public RoleService(DB context, IMapper mapper, RoleQuery roleQuery)
        {
            _context = context;
            _mapper = mapper;
            _roleQuery = roleQuery;
        }
        public async Task<RoleOnlyResponse> CreateRoleAsync([FromBody] string roleName, ClaimsPrincipal user)
        {
            var role = new Role
            {
                Name = roleName,
                CreatorID = AuthenticationHelper.GetUserIDAsync(user),
                CreatedOn = PresentDateTimeFetcher.FetchPresentDateTime(),
                RecordStatus = RecordStatus.Active
            };

            await _context.Role.AddAsync(role);
            await _context.SaveChangesAsync();


            return await _roleQuery.RoleOnlyResponseByIDAsync(role.ID);
        }
        public async Task<RoleOnlyResponse> PatchRoleByIDAsync([FromQuery] int ID,[FromBody] string roleName, ClaimsPrincipal user)
        {
            var query = await _roleQuery.PatchRoleByIDAsync(ID);

            query.Name = roleName;

            await _context.SaveChangesAsync();

            var roleLog = new RoleLog
            {
                RoleID = query.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.RoleLog.AddAsync(roleLog);
            await _context.SaveChangesAsync();

            return await _roleQuery.RoleOnlyResponseByIDAsync(query.ID);
        }
        public async Task<RoleOnlyResponse> PatchRoleStatusByIDAsync([FromQuery] int ID, RecordStatus status, ClaimsPrincipal user)
        {
            var query = await _roleQuery.PatchRoleByIDAsync(ID);

            query.RecordStatus = status;

            await _context.SaveChangesAsync();

            var roleLog = new RoleLog
            {
                RoleID = query.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.RoleLog.AddAsync(roleLog);
            await _context.SaveChangesAsync();

            return await _roleQuery.RoleOnlyResponseByIDAsync(query.ID);
        }
        public async Task<RoleOnlyResponse> DeleteRoleByIDAsync(int ID)
        {
            var query = await _roleQuery.PatchRoleByIDAsync(ID);

            _context.Role.Remove(query);
            await _context.SaveChangesAsync();

            return await _roleQuery.RoleOnlyResponseByIDAsync(query.ID);
        }
        public async Task<RoleOnlyResponse> GetRoleByIDAsync([FromQuery] int ID)
        {
            return await _roleQuery.RoleOnlyResponseByIDAsync(ID);
        }
        public async Task<Paginate<RoleOnlyResponse>> GetPaginatedRolesAsync(
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            [FromQuery] string? searchTerm,
            [FromQuery] RecordStatus? status)
        {
            var query = _roleQuery.RoleOnlyResponseAsync(searchTerm, status);
            return await PaginationHelper.PaginateAndMap(query, pageNumber, pageSize);
        }
        public async Task<List<RoleOnlyResponse>> GetListedRolesAsync([FromQuery] string? searchTerm, RecordStatus? status)
        {
            return await _roleQuery.RoleOnlyResponseAsync(searchTerm, status).ToListAsync();
        }
    }
}