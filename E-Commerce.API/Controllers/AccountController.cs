using E_Commerce.Application.DTOs.AuthDTO;
using E_Commerce.Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> RegisterAsync(RegisterDto user)

        {
            var Register = await _authService.RegisterAsync(user);
            if (Register == null) { return BadRequest(new { message = "Registration Failed" }); }
            return Ok(Register);
        }

        [HttpPost("Login")]

        public async Task<ActionResult<UserDto>> LoginAsync(LoginDto login)
        {
            var user = await _authService.LoginAsync(login);
            if (user == null) { return Unauthorized(); }
            return Ok(user);
        }
    }
}
