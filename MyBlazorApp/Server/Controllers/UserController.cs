using Microsoft.AspNetCore.Mvc;
using MyBlazorApp.Server.Interfaces;
using MyBlazorApp.Shared.Models;

namespace MyBlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<List<UserDto>> GetAll()
        {
            return await Task.FromResult(_userService.GetUserDetails());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            UserDto user = _userService.GetUserData(id);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public void Post([FromBody] UserDto user)
        {
            _userService.AddUser(user);
        }

        [HttpPut]
        public void Put(UserDto user)
        {
            _userService.UpdateUserDetails(user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.DeleteUser(id);
            return Ok();
        }
    }
}

