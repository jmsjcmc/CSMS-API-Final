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
        [HttpPost("user/create")]
        public async Task<ActionResult<UserWithBusinessUnitAndPositonResponse>> CreateUserAsync(CreateUserRequest request)
        {
            var response = await _userService.CreateUserAsync(request, User);
            return response;
        }
        [HttpPatch("user/update/{id}")]
        public async Task<ActionResult<UserWithBusinessUnitAndPositonResponse>> UpdateUserByIDAsync(int ID, CreateUserRequest request)
        {
            var response = await _userService.UpdateUserByIDAsync(ID, request, User);
            return response;
        }
    }
}
