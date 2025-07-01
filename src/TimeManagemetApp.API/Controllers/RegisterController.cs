using Microsoft.AspNetCore.Mvc;
using TimeManagemetApp.Models.Models;
using TimeManagemetApp.BusinessLogic.Services;
using System.Threading.Tasks;

namespace TimeManagemetApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly UserService _userService;
        public RegisterController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] LoginRequest request)
        {
            if (await _userService.UserExistsAsync(request.Username))
            {
                return BadRequest("Username already exists");
            }
            var user = await _userService.RegisterAsync(request.Username, request.Password);
            return Ok(new { user.Id, user.Username });
        }
    }
}
