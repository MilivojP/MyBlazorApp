using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlazorApp.Server.Interfaces;

namespace MyBlazorApp.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost, Route("login")]
        public IActionResult Login(string email, string password)
        {
            var token = _authService.Login(email, password);

            if (token == null)
            {
                return Unauthorized();
            }    
            else
            {
                return Ok(token);
            }
        }

        [HttpPost, Route("logout")]
        public IActionResult Logout()
        {
            return Ok();
        }
    }
}
