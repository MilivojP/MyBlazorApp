using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlazorApp.BL.Interfaces;
using MyBlazorApp.Shared.Models;

namespace MyBlazorApp.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTimeController : ControllerBase
    {
        private readonly IProjectTimeService _projectTimeService;
    
        public ProjectTimeController(IProjectTimeService projectTimeService)
        {
            _projectTimeService = projectTimeService;

        }
    
        [HttpGet]
        public ActionResult<List<ProjectTimeDto>> GetAll()
        {
            return Ok(_projectTimeService.GetProjectTimes());
        }


        [HttpGet("{Id}")]

        public ActionResult<ProjectTimeDto> Get(int id)
        {
            var Id = _projectTimeService.GetProjectTime(id);
            
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
        public ActionResult Post([FromBody] NewProjectTimeDto projectTime)
        {
            try
            {
                _projectTimeService.AddProjectTime(projectTime);
                return Ok(ModelState);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("day", ex.Message);
                return BadRequest(ModelState);
            }
            
        }

        [HttpPut]
        public void Put(ProjectTimeDto projectTime)
        {
            _projectTimeServices.UpdateProjectTime(projectTime);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _projectTimeService.DeleteProjectTime(Id);
            return Ok();
        }
    }
}
