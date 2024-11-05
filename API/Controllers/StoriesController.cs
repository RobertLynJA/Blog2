using API.Models.Stories;
using DataFacade.Commands.Stories;
using MediatR;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StoriesController(ILogger<StoriesController> logger, IMediator mediator) : ControllerBase
{
    private readonly ILogger<StoriesController> _logger = logger;
    private readonly IMediator _mediator = mediator;

    // GET <StoriesController>
    [HttpGet()]
    [ResponseCache(CacheProfileName = "10MinutesPublic")]
    public async Task<ActionResult<List<Models.Stories.Story>>> Get(CancellationToken cancellationToken)
    {
        try
        {
            var stories = await _mediator.Send(new GetStoriesByDateCommand(0, 10), cancellationToken);
            var result = stories.Select(s => Story.FromDAO(s)).ToList();

            _logger.LogInformation("URL: {URL}", Request.GetDisplayUrl());

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

            var result = Story.FromDAO(story);

            _logger.LogInformation("URL: {URL}", Request.GetDisplayUrl());

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "URL: {URL}", Request.GetDisplayUrl());
            throw;
        }
    }
}
