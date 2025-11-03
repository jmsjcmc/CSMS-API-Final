using AutoMapper;
using CSMS_API.Models;
using CSMS_API.Utils;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CSMS_API.Controllers
{
    public interface UserInterface
    {
        Task<object> UserLoginAsync(UserLoginRequest request);
        Task<UserWithBusinessUnitAndPositonResponse> CreateUserAsync(CreateUserRequest request, ClaimsPrincipal authUser);
        Task<UserWithBusinessUnitAndPositonResponse> UpdateUserByIDAsync(int ID, UpdateUserRequest request, ClaimsPrincipal authUser);
        Task<UserWithBusinessUnitAndPositonResponse> AddPositionToUserByIDAsync(int userID, int positionID, ClaimsPrincipal authUser);
        Task<UserWithBusinessUnitAndPositonResponse> DeleteUserByIDAsync(int ID);
        Task<UserWithBusinessUnitAndPositonResponse> GetUserByIDAsync(int ID);
        Task<UserWithBusinessUnitAndPositonResponse> AuthenticatedUserDetailsAsync(ClaimsPrincipal userDetail);
    }
    public class UserService : UserInterface
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

                return _mapper.Map<UserWithBusinessUnitAndPositonResponse>(user);
            }
        }
        public async Task<UserWithBusinessUnitAndPositonResponse> UpdateUserByIDAsync(int ID, UpdateUserRequest request, ClaimsPrincipal authUser)
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

            return _mapper.Map<UserWithBusinessUnitAndPositonResponse>(user);
        }
        public async Task<UserWithBusinessUnitAndPositonResponse> AddPositionToUserByIDAsync(int userID, int positionID, ClaimsPrincipal authUser)
        {
            var user = await _userQuery.PatchUserByIDAsync(userID);
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
            return _mapper.Map<UserWithBusinessUnitAndPositonResponse>(user);
        }
        public async Task<UserWithBusinessUnitAndPositonResponse> DeleteUserByIDAsync(int ID)
        {
            var user = await _userQuery.PatchUserByIDAsync(ID);

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserWithBusinessUnitAndPositonResponse>(user);
        }
        public async Task<UserWithBusinessUnitAndPositonResponse> GetUserByIDAsync(int ID)
        {
            var user = await _userQuery.GetUserByIDAsync(ID);
            return _mapper.Map<UserWithBusinessUnitAndPositonResponse>(user);
        }
        public async Task<UserWithBusinessUnitAndPositonResponse> AuthenticatedUserDetailsAsync(ClaimsPrincipal userDetail)
        {
            var userIDClaim = userDetail.FindFirst(ClaimTypes.NameIdentifier)
                ?? throw new UnauthorizedAccessException("User ID claim not found");

            if (!int.TryParse(userIDClaim.Value, out var userID))
                throw new UnauthorizedAccessException("Invalid user ID claim");

            var user = await _userQuery.GetUserByIDAsync(userID);
            return _mapper.Map<UserWithBusinessUnitAndPositonResponse>(user);
        }
    }
}
