using DataFacade.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController : ControllerBase
    {
        private ILogger _Logger;

        public StoriesController(ILogger logger) 
        {
            _Logger = logger;
        }

        // GET api/<StoriesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Story), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            return NotFound();
        }
    }
}
