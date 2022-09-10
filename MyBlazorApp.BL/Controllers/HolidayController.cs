using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlazorApp.Server.Interfaces;
using MyBlazorApp.Shared.Models;

namespace MyBlazorApp.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : ControllerBase
    {
        private readonly IHolidayService _holidayServices;
        public HolidayController(IHolidayService holidayServices)
        {
            _holidayServices = holidayServices;
        }

        [HttpGet]
        public ActionResult<List<HolidayDto>> GetAll()
        {
            return Ok(_holidayServices.GetHolidays());
        }


        [HttpGet("{Id}")]

        public ActionResult<HolidayDto> Get(int id)
        {
            var Id = _holidayServices.GetHoliday(id);
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
        public ActionResult Post([FromBody] HolidayDto holiday)
        {
            try
            {
                _holidayServices.AddHoliday(holiday);
                return Ok(ModelState);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("holiday", ex.Message);
                return BadRequest(ModelState);
            }
            
        }

        [HttpPut]
        public void Put(HolidayDto holiday)
        {
            _holidayServices.UpdateHoliday(holiday);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _holidayServices.DeleteHoliday(Id);
            return Ok();
        }
    }
}
