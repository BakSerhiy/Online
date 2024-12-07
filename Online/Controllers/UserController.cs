using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Online.Entities;
using Online.Services;
using LoginRequest = Online.Entities.LoginRequest;

namespace Online.Controllers;


    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AuthService _authService;

        public UserController(AuthService authService)
        {
            _authService = authService;
        }

        // POST: api/user/register
        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            try
            {
                _authService.Register(user);
                return Ok(new { Message = "Користувача успішно зареєстровано" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        // POST: api/user/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                var user = _authService.Login(loginRequest.Email, loginRequest.Password);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return Unauthorized(new { Error = ex.Message });
            }
        }

        // PUT: api/user/edit/{id}
        [HttpPut("edit/{id}")]
        public IActionResult EditProfile(int id, [FromBody] User updatedUser)
        {
            try
            {
                _authService.EditProfile(id, updatedUser);
                return Ok(new { Message = "Профіль оновлено" });
            }
            catch (Exception ex)
            {
                return NotFound(new { Error = ex.Message });
            }
        }
    }
