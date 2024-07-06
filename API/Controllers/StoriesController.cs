using AutoMapper;
using DataFacade.Commands.Stories;
using MediatR;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesController(ILogger<StoriesController> logger, IMapper mapper, IMediator mediator) : ControllerBase
    {
        private readonly ILogger<StoriesController> _logger = logger;
        private readonly IMapper _mapper = mapper;
        private readonly IMediator _mediator = mediator;

        // GET <StoriesController>
        [HttpGet()]
        [ProducesResponseType(typeof(Models.Stories.Story), StatusCodes.Status200OK)]
        [ResponseCache(CacheProfileName = "10MinutesPublic")]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            try
            {
                var stories = await _mediator.Send(new GetStoriesByDateCommand(0, 10), cancellationToken);
                var result = _mapper.Map<IEnumerable<Models.Stories.Story>>(stories);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "URL: {URL}", Request.GetDisplayUrl());
                throw;
            }
        }

        // GET <StoriesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Models.Stories.Story), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "10MinutesPublic")]
        public async Task<IActionResult> Get(string id, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return NotFound();
                }

                var story = await _mediator.Send(new GetStoryByIDCommand(id), cancellationToken);

                if (story == null)
                {
                    return NotFound();
                }

                var result = _mapper.Map<Models.Stories.Story>(story);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "URL: {URL}", Request.GetDisplayUrl());
                throw;
            }
        }
    }
}
