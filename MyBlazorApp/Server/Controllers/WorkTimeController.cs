using Microsoft.AspNetCore.Mvc;
using MyBlazorApp.Server.Interfaces;
using MyBlazorApp.Shared.Models;

namespace MyBlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkTimeController : ControllerBase
    {
        private readonly IWorkTimeServices _workTimeServices;
        public WorkTimeController(IWorkTimeServices workTimeServices)
        {
            _workTimeServices = workTimeServices;
        }
        
        [HttpGet]
        public async Task<List<WorkTime>> Get()
        {
            return await Task.FromResult(_workTimeServices.GetWorkTimeDetails());
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            WorkTime UserId= _workTimeServices.GetWorkTimeData(id);
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
        public void Post([FromBody] WorkTime UserName)
        {
            _workTimeServices.AddWorkTime(UserName);
        }

        [HttpPut]
        public void Put(WorkTime UserName)
        {
            _workTimeServices.UpdateWorkTimeDetails(UserName);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int UserId)
        {
            _workTimeServices.DeleteWorkTime(UserId);
            return Ok();
        }
    }
}
