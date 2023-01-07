using AutoMapper;
using DataFacade.DataSource.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController : ControllerBase
    {
        private readonly ILogger<StoriesController> _logger;
        private readonly IStoriesDataSource _storiesDataSource;
        private readonly IMapper _mapper;

        public StoriesController(ILogger<StoriesController> logger, IStoriesDataSource storiesDataSource, IMapper mapper) 
        {
            _logger = logger;
            _storiesDataSource = storiesDataSource;
            _mapper = mapper;
        }

        // GET <StoriesController>
        [HttpGet("ByDate")]
        [ProducesResponseType(typeof(Models.Stories.Story), StatusCodes.Status200OK)]
        [ResponseCache(CacheProfileName = "10MinutesPublic")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var stories = await _storiesDataSource.GetStoriesByDateAsync(0, 10);
                var result = _mapper.Map<IEnumerable<Models.Stories.Story>>(stories);

                return Ok(result);
            }
            catch (Exception ex)
        {
                _logger.LogError(ex, "StoriesController.Get");
                throw;
            }
        }

        // GET <StoriesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Models.Stories.Story), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(string id)
        {
            return NotFound();
        }
    }
}
