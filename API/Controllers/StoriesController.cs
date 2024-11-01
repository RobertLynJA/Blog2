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
        [ResponseCache(CacheProfileName = "10MinutesPublic")]
        public async Task<ActionResult<List<Models.Stories.Story>>> Get(CancellationToken cancellationToken)
        {
            try
            {
                var stories = await _mediator.Send(new GetStoriesByDateCommand(0, 10), cancellationToken);
                var result = _mapper.Map<IEnumerable<Models.Stories.Story>>(stories).ToList();

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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ResponseCache(CacheProfileName = "10MinutesPublic")]
        public async Task<ActionResult<Models.Stories.Story>> Get(string id, CancellationToken cancellationToken)
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
