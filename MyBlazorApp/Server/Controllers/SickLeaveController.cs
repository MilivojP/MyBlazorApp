using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlazorApp.Server.Interfaces;
using MyBlazorApp.Shared.Models;

namespace MyBlazorApp.Server.Controllers
{
//    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SickLeaveController : ControllerBase
    {
        private readonly ISickLeaveService _sickLeaves;
        public SickLeaveController(ISickLeaveService sickLeave)
        {
            _sickLeaves = sickLeave;
        }

        [HttpGet]
        public ActionResult<List<SickLeaveDto>> GetAll()
        {
            return Ok(_sickLeaves.GetSickLeaves());
        }


        [HttpGet("{Id}")]

        public ActionResult<SickLeaveDto> Get(int id)
        {
            var Id = _sickLeaves.GetSickLeave(id);
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
        public ActionResult Post([FromBody] SickLeaveDto sickLeave)
        {
            try
            {
                _sickLeaves.AddSickLeave(sickLeave);
                return Ok(ModelState);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("type", ex.Message);
                return BadRequest(ModelState);
            }
            
        }

        [HttpPut]
        public void Put(SickLeaveDto sickLeave)
        {
            _sickLeaves.UpdateSickLeave(sickLeave);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _sickLeaves.DeleteSickLeave(Id);
            return Ok();
        }
    }
}
