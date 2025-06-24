using Microsoft.AspNetCore.Mvc;
using OcelotAuthentication.Models;
using OcelotAuthentication.Services;

namespace OcelotAuthentication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<AuthController> _logger;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthController(ILogger<AuthController> logger, IJwtTokenService jwtTokenService)
        {
            _logger = logger;
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginModel login)
        {
           var loginResult = _jwtTokenService.GenereateAuthToken(login);
            return string.IsNullOrEmpty(loginResult.Token)
                ? Unauthorized("Invalid username or password.")
                : Ok(loginResult);
        }
    }
}
