using Backend;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) => _authService = authService;

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            var user = await _authService.Register(registerDTO);

            if (user is null) return BadRequest("User Is Not Created");

            return Ok("User Created");
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDTO loginDTO)
        {
            var result = await _authService.Login(loginDTO);

            if (result is null) return BadRequest("Wrong Email or Password");

            return Ok(result);
        }

    }
}
