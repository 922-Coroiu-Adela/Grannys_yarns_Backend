using Grannys_yarns_API.Model;
using Grannys_yarns_API.Repository;
using Grannys_yarns_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Grannys_yarns_API.Controllers
{
    [ApiController]
    [Route("granny's_yarns")]
    public class GrannyYarnsController : Controller
    {
        private iService service;
        private ILogger<Controller> _logger;

        public GrannyYarnsController(ILogger<Controller> logger, iService service) 
        { 
            this._logger = logger;
            this.service = service;
        }

        [HttpGet("yarns", Name = "GetAllYarns")]
        public IEnumerable<Yarn> GetAllYarns()
        {
            return service.GetAllYarns();
        }

        [HttpGet("yarns/{id}", Name = "GetYarn")]
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

        [HttpPost("yarns/add", Name = "AddYarn")]
        public IActionResult AddYarn([FromBody] YarnDataTransferObject yarnDTO)
        {
            if (yarnDTO == null)
            {
                return BadRequest("Yarn not added");
            }
            var yarn = new Yarn
            {
                did = yarnDTO.did,
                name = yarnDTO.name,
                color = yarnDTO.color,
                price = yarnDTO.price,
                quantity = yarnDTO.quantity,
                size = yarnDTO.size,
            };
            try
            {
                service.AddYarn(yarn);
                return Ok("Yarn added successfully");
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest("Yarn not added");
            }
            
        }

        [HttpPut("yarns/update", Name = "UpdateYarn")]
        public IActionResult UpdateYarn([FromBody] YarnDataTransferObject updatedYarnDTO)
        {
            if (updatedYarnDTO == null)
            {
                return BadRequest("Invalid yarn in request body");
            }
            var updatedYarn = new Yarn
            {
                yid = updatedYarnDTO.yid,
                did = updatedYarnDTO.did,
                name = updatedYarnDTO.name,
                color = updatedYarnDTO.color,
                price = updatedYarnDTO.price,
                quantity = updatedYarnDTO.quantity,
                size = updatedYarnDTO.size,
            };
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

        [HttpDelete("yarns/delete/{id}", Name = "DeleteYarn")]
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

        [HttpGet("distributors", Name = "GetAllDistributors")]
        public IEnumerable<Distributor> GetAllDistributors()
        {
            return service.GetAllDistributors();
        }

        [HttpGet("distributors/{id}", Name = "GetDistributor")]
        public Distributor GetDistributor(int id)
        {
            try
            {
                return service.GetDistributor(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return null;
            }
        }

        [HttpPost("distributors/add", Name = "AddDistributor")]
        public IActionResult AddDistributor([FromBody] DistributorDataTransferObject distributor)
        {
            if (distributor == null)
            {
                return BadRequest("Distributor not added");
            }
            var newDistributor = new Distributor
            {
                name = distributor.name,
                address = distributor.address,
                phone = distributor.phone,
                username = distributor.username,
                password = distributor.password
            };
            service.AddDistributor(newDistributor);
            return Ok("Distributor added successfully");
        }

        [HttpPut("distributors/update", Name = "UpdateDistributor")]
        public IActionResult UpdateDistributor([FromBody] DistributorDataTransferObject updatedDistributor)
        {
            if (updatedDistributor == null)
            {
                return BadRequest("Invalid distributor in request body");
            }
            var distributor = new Distributor
            {
                did = updatedDistributor.did,
                name = updatedDistributor.name,
                address = updatedDistributor.address,
                phone = updatedDistributor.phone,
            };
            try
            {
                service.UpdateDistributor(distributor);
                return Ok("Distributor successfully updated");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return NotFound("Distributor not found");
            }
        }

        [HttpDelete("distributors/delete/{id}", Name = "DeleteDistributor")]
        public IActionResult DeleteDistributor(int id)
        {
            try
            {
                service.DeleteDistributor(id);
                return Ok("Distributor successfully deleted");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return NotFound("Distributor not found");
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] DistributorLoginDataTransferObject credentials)
        {
            if (credentials.username == null || credentials.password == null)
            {
                return BadRequest("Invalid username or password");
            }

            if (service.GetDistributorByUsername(credentials.username) == null)
            {
                return NotFound("Invalid username!");
            }

            if (service.GetDistributorByUsername(credentials.username).password != credentials.password)
            {
                return NotFound("Invalid password!");
            }

            try
            {
                var session = service.GenerateSessions(service.GetDistributorByUsername(credentials.username).did);
                return Ok(session);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout([FromBody] Session session)
        {
            if (session == null)
            {
                return BadRequest("Invalid session in request body");
            }
            try
            {
                service.RemoveSession(session.did);
                return Ok("Session removed");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
