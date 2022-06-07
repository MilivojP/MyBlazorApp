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
        public async Task<List<WorkTimeDto>> Get()
        {
            return await Task.FromResult(_workTimeServices.GetWorkTimeDetails());
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            WorkTimeDto UserId = _workTimeServices.GetWorkTimeData(id);
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
        public void Post([FromBody] WorkTimeDto workTime)
        {
            _workTimeServices.AddWorkTime(workTime);
        }

        [HttpPut]
        public void Put(WorkTimeDto workTime)
        {
            _workTimeServices.UpdateWorkTimeDetails(workTime);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int UserId)
        {
            _workTimeServices.DeleteWorkTime(UserId);
            return Ok();
        }
    }
}
