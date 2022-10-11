using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlazorApp.BL.Interfaces;
using MyBlazorApp.Shared.Models;
using System.Security.Claims;

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
        public IActionResult Login([FromBody] LoginDto login)
        {
            var token = _authService.Login(login.Email, login.Password);

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

        [AllowAnonymous]
        [HttpGet, Route("id")]
        public ActionResult<int> GetCurrentUserId()
        {
            var z = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;

            return int.Parse(z);
        }
    }
}
