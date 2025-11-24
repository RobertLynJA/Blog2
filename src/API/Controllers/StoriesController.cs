using API.Models.Stories;
using DataFacade.Commands.Stories;
using Wolverine;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StoriesController(ILogger<StoriesController> logger, IMessageBus bus) : ControllerBase
{
    private readonly ILogger<StoriesController> _logger = logger;
    private readonly IMessageBus _bus = bus;

    // GET <StoriesController>
    [HttpGet()]
    [ResponseCache(CacheProfileName = "10MinutesPublic")]
    public async Task<ActionResult<List<Models.Stories.Story>>> Get(int page = 0, int pageSize = 20, CancellationToken cancellationToken = default)
    {
        try
        {
            var stories = await _bus.InvokeAsync<IReadOnlyList<DataFacade.Models.Stories.Story>>(new GetStoriesByDateCommand(page, pageSize), cancellationToken);
            var result = stories.Select(s => Story.FromDao(s)).ToList();

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

            var story = await _bus.InvokeAsync<DataFacade.Models.Stories.Story?>(new GetStoryByIdCommand(id), cancellationToken);

            if (story == null)
            {
                return NotFound();
            }

            var result = Story.FromDao(story);

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
