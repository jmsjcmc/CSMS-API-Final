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
            var user = _mapper.Map<User>(request);

            user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.CreatorID = AuthenticationHelper.GetUserIDAsync(authUser);
            user.CreatedOn = PresentDateTimeFetcher.FetchPresentDateTime();
            user.RecordStatus = RecordStatus.Active;

            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserWithBusinessUnitAndPositonResponse>(user);
        }
        public async Task<UserWithBusinessUnitAndPositonResponse> UpdateUserByIDAsync(int ID, UpdateUserRequest request, ClaimsPrincipal authUser)
        {
            var user = await _userQuery.PatchUserByIDAsync(ID);

            _mapper.Map(user, request);

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
    }
}
