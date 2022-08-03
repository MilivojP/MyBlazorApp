using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlazorApp.Server.Interfaces;
using MyBlazorApp.Shared.Models;

namespace MyBlazorApp.Server.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VacationController : ControllerBase
    {
        private readonly IVacationService _vacationServices;

        public VacationController(IVacationService vacationServices)
        {
            _vacationServices = vacationServices;
        }

        [HttpGet]
        public ActionResult<List<VacationDto>> GetAll()
        {
            return Ok(_vacationServices.GetVacations());
        }


        [HttpGet("{Id}")]

        public ActionResult<ExistingVacationDto> Get(int id)
        {
            var Id = _vacationServices.GetVacation(id);
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
        public ActionResult Post([FromBody] NewVacationDto vacation)
        {
            try
            {
                _vacationServices.AddVacation(vacation);
                return Ok(ModelState);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("vacation", ex.Message);
                return BadRequest(ModelState);
            }
            
        }

        [HttpPut]
        public void Put(ExistingVacationDto vacation)
        {
            _vacationServices.UpdateVacation(vacation);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _vacationServices.DeleteVacation(Id);
            return Ok();
        }
    }
}
