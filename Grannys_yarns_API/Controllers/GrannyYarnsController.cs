using Grannys_yarns_API.Model;
using Grannys_yarns_API.Repository;
using Grannys_yarns_API.Service;
using Microsoft.AspNetCore.Mvc;

namespace Grannys_yarns_API.Controllers
{
    [ApiController]
    [Route("yarns")]
    public class GrannyYarnsController : Controller
    {
        private iService service;
        private ILogger<Controller> _logger;

        public GrannyYarnsController(ILogger<Controller> logger) 
        { 
            this._logger = logger;
            this.service = new Service.Service(new MemoryRepository());
        }

        [HttpGet("", Name = "GetAllYarns")]
        public IEnumerable<Yarn> GetAllYarns()
        {
            return service.GetAllYarns();
        }

        [HttpGet("{id}", Name = "GetYarn")]
        public Yarn GetYarn(int id)
        {
            try
            {                 
                return service.GetYarn(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return null;
            }
        }

        [HttpPost("add", Name = "AddYarn")]
        public IActionResult AddYarn([FromBody] Yarn yarn)
        {
            if (yarn == null)
            {
                return BadRequest("Yarn not added");
            }
            service.AddYarn(yarn);
            return Ok("Yarn added successfully");
        }

        [HttpPut("update", Name = "UpdateYarn")]
        public IActionResult UpdateYarn([FromBody] Yarn updatedYarn)
        {
            if (updatedYarn == null)
            {
                return BadRequest("Invalid yarn in request body");
            }
            try
            {
                service.UpdateYarn(updatedYarn);
                return Ok("Yarn successfully updated");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return NotFound("Yarn not found");
            }
            
        }

        [HttpDelete("delete/{id}", Name = "DeleteYarn")]
        public IActionResult DeleteYarn(int id)
        {
            try
            {
                service.DeleteYarn(id);
                return Ok("Yarn successfully deleted");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return NotFound("Yarn not found");
            }
        }
    }
}
