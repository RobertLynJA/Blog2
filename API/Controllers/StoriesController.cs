using API.Models.Stories;
using AutoMapper;
using DataFacade.DataSource.Interfaces;
using DataFacade.Messages.Stories;
using MediatR;
using Microsoft.AspNetCore.Http.Extensions;
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
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public StoriesController(ILogger<StoriesController> logger, IMapper mapper, IMediator mediator)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
        }

        // GET <StoriesController>
        [HttpGet("ByDate")]
        [ProducesResponseType(typeof(Models.Stories.Story), StatusCodes.Status200OK)]
        [ResponseCache(CacheProfileName = "10MinutesPublic")]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            try
            {
                var stories = await _mediator.Send(new GetStoriesByDate(0, 10), cancellationToken);
                var result = _mapper.Map<IEnumerable<Models.Stories.Story>>(stories);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, Request.GetDisplayUrl());
                throw;
            }
        }

        // GET <StoriesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Models.Stories.Story), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(string id, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return NotFound();
                }

                var story = await _mediator.Send(new GetStoryByID(id));

                if (story == null)
                {
                    return NotFound();
                }

                var result = _mapper.Map<Models.Stories.Story>(story);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, Request.GetDisplayUrl());
                throw;
            }
        }
    }
}
