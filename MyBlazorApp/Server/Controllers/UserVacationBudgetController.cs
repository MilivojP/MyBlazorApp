using MyBlazorApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using MyBlazorApp.Server.Interfaces;

namespace MyBlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserVacationBudgetController : ControllerBase
    {
        private readonly IUserVacationBudgetService _userVacationBudgets;

        public UserVacationBudgetController (IUserVacationBudgetService userVacationBudgetService)
        {
            _userVacationBudgets= userVacationBudgetService;
        }

        [HttpGet]
        public ActionResult<List<UserVacationBudgetDto>> GetAll()
        {
            return Ok(_userVacationBudgets.GetUserVacationsBudget());
        }

        [HttpGet("{id}")]
        public ActionResult<UserVacationBudgetDto> Get(int id)
        {
            var Id = _userVacationBudgets.GetUserVacationBudgetDto(id);
            if (Id != null)
            {
                return Ok(Id);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] UserVacationBudgetDto budget)
        {
            try
            {
                _userVacationBudgets.AddUserVacationBudget(budget);
                return Ok(ModelState);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("year", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public void Put(UserVacationBudgetDto budget)
        {
            _userVacationBudgets.UpdateUserVacationBudget(budget);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _userVacationBudgets.DeleteUserVacationBudgetDto(Id);
            return Ok();
        }

    }
}
