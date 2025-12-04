using AutoMapper;
using CSMS_API.Models;
using CSMS_API.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CSMS_API.Controllers
{
    public class UserService : UserServiceInterface
    {
        private readonly DB _context;
        private readonly IMapper _mapper;
        private readonly UserQuery _userQuery;
        private readonly AuthenticationHelper _authHelper;
        public UserService(DB context, IMapper mapper, UserQuery userQuery, AuthenticationHelper authHelper)
        {
            _context = context;
            _mapper = mapper;
            _userQuery = userQuery;
            _authHelper = authHelper;
        }
        public async Task<object> UserLoginAsync(UserLoginRequest request)
        {
            var user = await _context.User
                .Include(u => u.UserRole!)
                .ThenInclude(ur => ur.Role)
                .SingleOrDefaultAsync(u => u.Username == request.Username);

            var accessToken = _authHelper.GenerateAccessToken(user);
            await _context.SaveChangesAsync();

            return new
            {
                AccessToken = accessToken
            };
        }
        public async Task<UserWithBusinessUnitAndPositonResponse> CreateUserAsync(CreateUserRequest request, ClaimsPrincipal authUser)
        {
            if (await _context.User.AnyAsync(u => u.Username == request.Username))
            {
                throw new Exception($"Username {request.Username} already exist");
            }
            else
            {
                var user = _mapper.Map<User>(request);

                user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
                user.CreatorID = AuthenticationHelper.GetUserIDAsync(authUser);
                user.CreatedOn = PresentDateTimeFetcher.FetchPresentDateTime();
                user.RecordStatus = RecordStatus.Active;

                await _context.User.AddAsync(user);
                await _context.SaveChangesAsync();

                return await _userQuery.UserWithBusinessUnitAndPositonResponseByIDAsync(user.ID);
            }
        }
        public async Task<UserWithBusinessUnitAndPositonResponse> PatchUserByIDAsync(int ID, UpdateUserRequest request, ClaimsPrincipal authUser)
        {
            var user = await _userQuery.PatchUserByIDAsync(ID);

            _mapper.Map(request, user);

            await _context.SaveChangesAsync();

            var userLog = new UserLog
            {
                UserID = user.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(authUser),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };

            await _context.UserLog.AddAsync(userLog);
            await _context.SaveChangesAsync();

            return await _userQuery.UserWithBusinessUnitAndPositonResponseByIDAsync(user.ID);
        }
        public async Task<UserWithBusinessUnitAndPositonResponse> AddPositionToUserByIDAsync([FromQuery] int ID, [FromBody] int positionID, ClaimsPrincipal authUser)
        {
            var user = await _userQuery.PatchUserByIDAsync(ID);
            user.PositionID = positionID;

            await _context.SaveChangesAsync();

            var userLog = new UserLog
            {
                UserID = user.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(authUser),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };
            await _context.UserLog.AddAsync(userLog);
            await _context.SaveChangesAsync();

            return await _userQuery.UserWithBusinessUnitAndPositonResponseByIDAsync(user.ID);
        }
        public async Task<UserOnlyResponse> PatchUserStatusByIDAsync([FromQuery] int ID, RecordStatus status, ClaimsPrincipal user)
        {
            var query = await _userQuery.PatchUserByIDAsync(ID);

            query.RecordStatus = status;

            await _context.SaveChangesAsync();

            var userLog = new UserLog
            {
                UserID = query.ID,
                UpdaterID = AuthenticationHelper.GetUserIDAsync(user),
                UpdatedOn = PresentDateTimeFetcher.FetchPresentDateTime()
            };
            await _context.UserLog.AddAsync(userLog);
            await _context.SaveChangesAsync();

            return await _userQuery.UserOnlyResponseByIDAsync(query.ID);
        }
        public async Task<UserWithBusinessUnitAndPositonResponse> DeleteUserByIDAsync(int ID)
        {
            var user = await _userQuery.PatchUserByIDAsync(ID);

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return await _userQuery.UserWithBusinessUnitAndPositonResponseByIDAsync(user.ID);
        }
        public async Task<UserWithBusinessUnitAndPositonResponse> GetUserByIDAsync(int ID)
        {
            return await _userQuery.UserWithBusinessUnitAndPositonResponseByIDAsync(ID);
        }
        public async Task<UserWithBusinessUnitAndPositonResponse> GetAuthenticatedUserDetailsAsync(ClaimsPrincipal userDetail)
        {
            var userIDClaim = userDetail.FindFirst(ClaimTypes.NameIdentifier)
                ?? throw new UnauthorizedAccessException("USER ID CLAIM NOT FOUND");

            if (!int.TryParse(userIDClaim.Value, out var userID))
                throw new UnauthorizedAccessException("INVALID USER ID CLAIM");

            return await _userQuery.UserWithBusinessUnitAndPositonResponseByIDAsync(userID);
        }
        public async Task<Paginate<UserOnlyResponse>> GetPaginatedUsersAsync(
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            [FromQuery] string? searchTerm,
            [FromQuery] RecordStatus? status)
        {
            var query = _userQuery.UserOnlyResponseAsync(searchTerm, status);
            return await PaginationHelper.PaginateAndMap(query, pageNumber, pageSize);
        }
        public async Task<Paginate<UserWithBusinessUnitAndPositonResponse>> GetPaginatedUsersWithBusinessUnitAndPositionAsync(
            [FromQuery] int pageNumber,
            [FromQuery] int pageSize,
            [FromQuery] string? searchTerm,
            [FromQuery] RecordStatus? status)
        {
            var query = _userQuery.UserWithBusinessUnitAndPositonResponseAsync(searchTerm, status);
            return await PaginationHelper.PaginateAndMap(query, pageNumber, pageSize);
        }
        public async Task<List<UserOnlyResponse>> GetListedUsersAsync(string? searchTerm, RecordStatus? status)
        {
            return await _userQuery.UserOnlyResponseAsync(searchTerm, status).ToListAsync();
        }
        public async Task<List<UserWithBusinessUnitAndPositonResponse>> GetListedUsersWithBusinessUnitAndPositionAsync(string? searchTerm, RecordStatus? status)
        {
            return await _userQuery.UserWithBusinessUnitAndPositonResponseAsync(searchTerm, status).ToListAsync();
        }
    }
}
