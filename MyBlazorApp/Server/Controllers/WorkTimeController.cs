using Microsoft.AspNetCore.Mvc;
using MyBlazorApp.Server.Interfaces;
using MyBlazorApp.Shared.Models;

namespace MyBlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkTimeController : ControllerBase
    {
        private readonly IWorkTimeService _workTimeServices;
        public WorkTimeController(IWorkTimeService workTimeServices)
        {
            _workTimeServices = workTimeServices;
        }

        [HttpGet]
        public ActionResult<List<WorkTimeDto>> GetAll()
        {
            return Ok(_workTimeServices.GetWorkTimes());
        }


        [HttpGet("{Id}")]

        public ActionResult<ExistingWorkTimeDto> Get(int id)
        {
            var Id = _workTimeServices.GetWorkTime(id);
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
        public ActionResult Post([FromBody] NewWorkTimeDto workTime)
        {
            try
            {
                _workTimeServices.AddWorkTime(workTime);
                return Ok(ModelState);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("day", ex.Message);
                return BadRequest(ModelState);
            }
            
        }

        [HttpPut]
        public void Put(ExistingWorkTimeDto workTime)
        {
            _workTimeServices.UpdateWorkTime(workTime);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _workTimeServices.DeleteWorkTime(Id);
            return Ok();
        }
    }
}
