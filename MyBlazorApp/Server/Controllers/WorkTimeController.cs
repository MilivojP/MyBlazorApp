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
        //public async Task<List<WorkTimeDto>> Get()
        //{
        //    return await Task.FromResult(_workTimeServices.GetWorkTimes());
        //}

        [HttpGet("{id}")]

        public ActionResult<ExistingWorkTimeDto> Get(int id)
        {
            var UserId = _workTimeServices.GetWorkTime(id);
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

        [HttpDelete("{id}")]
        public IActionResult Delete(int UserId)
        {
            _workTimeServices.DeleteWorkTime(UserId);
            return Ok();
        }
    }
}
