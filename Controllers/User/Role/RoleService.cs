using AutoMapper;
using CSMS_API.Models;
using CSMS_API.Utils;
using System.Security.Claims;

namespace CSMS_API.Controllers
{
    public interface RoleInterface
    {
        Task<RoleOnlyResponse> CreateRoleAsync(string roleName, ClaimsPrincipal user);
        Task<RoleOnlyResponse> UpdateRoleByIDAsync(int ID, string roleName, ClaimsPrincipal user);
        Task<RoleOnlyResponse> UpdateRoleStatusByIDAsync(int ID, ClaimsPrincipal user);
        Task<RoleOnlyResponse> DeleteRoleByIDAsync(int ID);
        Task<RoleOnlyResponse> GetRoleByIDAsync(int ID);
        Task<Paginate<RoleOnlyResponse>> PaginatedRoles(
            int pageNumber,
            int pageSize,
            string searchTerm);
        Task<List<RoleOnlyResponse>> ListedRoles(string? searchTerm);
    }
    public class RoleService : RoleInterface
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
        public async Task<RoleOnlyResponse> CreateRoleAsync(string roleName, ClaimsPrincipal user)
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

            return _mapper.Map<RoleOnlyResponse>(role);
        }
        public async Task<RoleOnlyResponse> UpdateRoleByIDAsync(int ID, string roleName, ClaimsPrincipal user)
        {
            var role = await _roleQuery.PatchRoleByIDAsync(ID);

            role.Name = roleName;

            await _context.SaveChangesAsync();

            var roleLog = new RoleLog
            {
                RoleID = role.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.RoleLog.AddAsync(roleLog);
            await _context.SaveChangesAsync();

            return _mapper.Map<RoleOnlyResponse>(role);
        }
        public async Task<RoleOnlyResponse> UpdateRoleStatusByIDAsync(int ID, ClaimsPrincipal user)
        {
            var role = await _roleQuery.PatchRoleByIDAsync(ID);

            role.RecordStatus = role.RecordStatus == RecordStatus.Active
                ? RecordStatus.Inactive
                : RecordStatus.Active;

            await _context.SaveChangesAsync();

            var roleLog = new RoleLog
            {
                RoleID = role.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.RoleLog.AddAsync(roleLog);
            await _context.SaveChangesAsync();

            return _mapper.Map<RoleOnlyResponse>(role);
        }
        public async Task<RoleOnlyResponse> DeleteRoleByIDAsync(int ID)
        {
            var role = await _roleQuery.PatchRoleByIDAsync(ID);

            _context.Role.Remove(role);
            await _context.SaveChangesAsync();

            return _mapper.Map<RoleOnlyResponse>(role);
        }
        public async Task<RoleOnlyResponse> GetRoleByIDAsync(int ID)
        {
            var role = await _roleQuery.GetRoleByIDAsync(ID);
            return _mapper.Map<RoleOnlyResponse>(role);
        }
        public async Task<Paginate<RoleOnlyResponse>> PaginatedRoles(
            int pageNumber,
            int pageSize,
            string searchTerm)
        {
            var query = _roleQuery.PaginatedRoles(searchTerm);
            return await PaginationHelper.PaginateAndMapAsync<Role, RoleOnlyResponse>(query, pageNumber, pageSize, _mapper);
        }
        public async Task<List<RoleOnlyResponse>> ListedRoles(string? searchTerm)
        {
            var roles = await _roleQuery.ListedRoles(searchTerm);
            return _mapper.Map<List<RoleOnlyResponse>>(roles);
        }
    }
}