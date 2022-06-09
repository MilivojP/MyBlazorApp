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


        [HttpGet("{Userid}")]

        public ActionResult<ExistingWorkTimeDto> Get(int Userid)
        {
            var UserId = _workTimeServices.GetWorkTime(Userid);
            if (UserId != null)
            {
                return Ok(UserId);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]

        public void Post([FromBody] NewWorkTimeDto workTime)
        {
            _workTimeServices.AddWorkTime(workTime);
        }

        [HttpPut]
        public void Put(ExistingWorkTimeDto workTime)
        {
            _workTimeServices.UpdateWorkTime(workTime);
        }

        [HttpDelete("{Userid}")]
        public IActionResult Delete(int UserId)
        {
            _workTimeServices.DeleteWorkTime(UserId);
            return Ok();
        }
    }
}
