using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlazorApp.BL.Interfaces;
using MyBlazorApp.Server.Interfaces;
using MyBlazorApp.Shared.Models;

namespace MyBlazorApp.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
    
        public ProjectController(IProjectService projectServices)
        {
            _projectService = projectServices;

        }
    
        [HttpGet]
        public ActionResult<List<ProjectDto>> GetAll()
        {
            return Ok(_projectService.GetProjects());
        }


        [HttpGet("{Id}")]

        public ActionResult<ExistingProjectDto> Get(int id)
        {
            var Id = _projectService.GetProject(id);
            
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
        public ActionResult Post([FromBody] NewProjectDto project)
        {
            try
            {
                _projectService.AddProject(project);
                return Ok(ModelState);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("id", ex.Message);
                return BadRequest(ModelState);
            }
            
        }

        [HttpPut]
        public void Put(ExistingProjectDto project)
        {
            _projectService.UpdateProject(project);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _projectService.DeleteProject(Id);
            return Ok();
        }
    }
}
