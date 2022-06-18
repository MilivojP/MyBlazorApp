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
        public ActionResult<List<UserDto>> GetAll()
        {
            return Ok(_userService.GetUsers());
        }

        [HttpGet("{id}")]
        public ActionResult<ExistingUserDto> Get(int id)
        {
            var user = _userService.GetUser(id);
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
        public ActionResult Post([FromBody] NewUserDto user)
        {
            try
            {
                _userService.AddUser(user);
                return Ok(ModelState);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("email", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public void Put(ExistingUserDto user)
        {
            _userService.UpdateUser(user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.DeleteUser(id);
            return Ok();
        }

    
    }
}

