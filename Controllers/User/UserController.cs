using CSMS_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSMS_API.Controllers
{
    [Route("")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpPost("user/login")]
        public async Task<ActionResult<object>> UserLoginAsync(UserLoginRequest request)
        {
            var response = await _userService.UserLoginAsync(request);
            return response;
        }
        [HttpPost("user/create")]
        public async Task<ActionResult<UserWithBusinessUnitAndPositonResponse>> CreateUserAsync(CreateUserRequest request)
        {
            var response = await _userService.CreateUserAsync(request, User);
            return response;
        }
        [HttpPatch("user/update/{ID}")]
        public async Task<ActionResult<UserWithBusinessUnitAndPositonResponse>> UpdateUserByIDAsync(int ID, UpdateUserRequest request)
        {
            var response = await _userService.UpdateUserByIDAsync(ID, request, User);
            return response;
        }
        [HttpPatch("user/add-position/{userID}")]
        public async Task<ActionResult<UserWithBusinessUnitAndPositonResponse>> AddPositionToUserByIDAsync(int userID, int positionID)
        {
            var response = await _userService.AddPositionToUserByIDAsync(userID, positionID, User);
            return response;
        }
        [HttpDelete("user/delete/{ID}")]
        public async Task<ActionResult<UserWithBusinessUnitAndPositonResponse>> DeleteUserByIDAsync(int ID)
        {
            var response = await _userService.DeleteUserByIDAsync(ID);
            return response;
        }
        [HttpGet("user/{ID}")]
        public async Task<ActionResult<UserWithBusinessUnitAndPositonResponse>> GetUserByIDAsync(int ID)
        {
            var response = await _userService.GetUserByIDAsync(ID);
            return response;
        }
    }
}
