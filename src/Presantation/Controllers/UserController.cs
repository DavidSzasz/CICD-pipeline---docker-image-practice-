using Application.Dto.request;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();

            if (users == null)
            {
                return NotFound("No users found.");
            }

            return Ok(users);
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            return Ok(user);
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDto createUserRequestDto)
        {
            var createdUser = await _userService.CreateUserAsync(createUserRequestDto);
            if (createdUser == null)
            {
                return BadRequest("Failed to create user.");
            }
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserRequestDto updateUserRequestDto)
        {
            var success = await _userService.UpdateUserAsync(id, updateUserRequestDto);
            if (!success)
            {
                return NotFound("User not found or update failed.");
            }
            return NoContent();
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var success = await _userService.DeleteUserAsync(id);
            if (!success)
            {
                return NotFound("User not found.");
            }
            return NoContent();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequestDto loginRequestDto)
        {
            var userLogin = await _userService.LoginAsync(loginRequestDto.Username, loginRequestDto.Email, loginRequestDto.Password);
            if (userLogin == null)
            {
                return Unauthorized("Invalid credentials.");
            }

            return Ok(new
            {
                User = userLogin
            });
        }
    }
}