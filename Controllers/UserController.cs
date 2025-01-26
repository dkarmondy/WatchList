using WatchList.Dtos;
using WatchList.Services;
using Microsoft.AspNetCore.Mvc;

namespace WatchList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // // Register a new user
        // [HttpPost("register")]
        // public async Task<IActionResult> Register([FromBody] UserDto userDto, [FromQuery] string password)
        // {
        //     var user = await _userService.RegisterUserAsync(userDto, password);
        //     return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        // }

        // // Validate user login
        // [HttpPost("login")]
        // public async Task<IActionResult> Login([FromBody] UserDto userDto, [FromQuery] string password)
        // {
        //     var isValidUser = await _userService.ValidateUserAsync(userDto.Username, password);
        //     if (!isValidUser)
        //     {
        //         return Unauthorized();
        //     }

        //     return Ok(); // Optionally, return a JWT token or something similar here
        // }
    }
}
