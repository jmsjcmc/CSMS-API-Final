using AutoMapper;
using CSMS_API.Models;
using CSMS_API.Utils;
using System.Security.Claims;

namespace CSMS_API.Controllers
{
    public interface UserInterface
    {
        Task<UserWithBusinessUnitAndPositonResponse> CreateUserAsync(CreateUserRequest request, ClaimsPrincipal authUser);
        Task<UserWithBusinessUnitAndPositonResponse> UpdateUserByIDAsync(int ID, CreateUserRequest request, ClaimsPrincipal authUser);
    }
    public class UserService : UserInterface
    {
        private readonly DB _context;
        private readonly IMapper _mapper;
        private readonly UserQuery _userQuery;
        public UserService(DB context, IMapper mapper, UserQuery userQuery)
        {
            _context = context;
            _mapper = mapper;
            _userQuery = userQuery;
        }
        public async Task<UserWithBusinessUnitAndPositonResponse> CreateUserAsync(CreateUserRequest request, ClaimsPrincipal authUser)
        {
            var user = _mapper.Map<User>(request);

            user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.CreatorID = AuthenticationHelper.GetUserIDAsync(authUser);
            user.CreatedOn = PresentDateTimeFetcher.FetchPresentDateTime();

            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserWithBusinessUnitAndPositonResponse>(user);
        }
        public async Task<UserWithBusinessUnitAndPositonResponse> UpdateUserByIDAsync(int ID, CreateUserRequest request, ClaimsPrincipal authUser)
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
