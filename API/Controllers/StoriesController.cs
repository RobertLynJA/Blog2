using DataFacade.DataSource.Interfaces;
using DataFacade.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using System.Security.Cryptography.X509Certificates;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController : ControllerBase
    {
        private readonly ILogger<StoriesController> _logger;
        private readonly IStoriesDataSource _storiesDataSource;

        public StoriesController(ILogger<StoriesController> logger, IStoriesDataSource storiesDataSource) 
        {
            _logger = logger;
            _storiesDataSource = storiesDataSource;
        }

        // GET <StoriesController>
        [HttpGet("ByDate")]
        [ProducesResponseType(typeof(Story), StatusCodes.Status200OK)]
        [OutputCache(Duration = 600)]
        public IActionResult Get()
        {
            try
            {
                var stories = _storiesDataSource.GetStories();

                return Ok(stories);
            }
            catch (Exception ex)
        {
                _logger.LogError(ex, "StoriesController.Get");
                throw;
            }
        }

        // GET <StoriesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Story), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            return NotFound();
        }
    }
}
