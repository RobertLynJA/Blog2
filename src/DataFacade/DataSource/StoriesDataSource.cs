using Azure;
using DataFacade.DataSource.Interfaces;
using DataFacade.DB;
using DataFacade.Models.Stories;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFacade.DataSource;

public class StoriesDataSource : IStoriesDataSource
{
    private readonly ILogger<StoriesDataSource> _logger;
    private readonly CosmosDB _db;
    
    public StoriesDataSource(ILogger<StoriesDataSource> logger, CosmosDB db)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _db = db ?? throw new ArgumentNullException(nameof(db));

        _logger.LogInformation($"{nameof(StoriesDataSource)}()");
    }

    public Task<IReadOnlyList<Story>> GetStoriesAsync(int year, int month)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<Story>> GetStoriesByDateAsync(int page, int numberRows, CancellationToken cancellationToken = default)
    {
        var queryable = _db.StoriesContainer.GetItemLinqQueryable<Story>();

        var matches = queryable
            .OrderByDescending(s => s.PublishedDate)
            .Skip(page * numberRows)
            .Take(numberRows);

        using var feed = matches.ToFeedIterator<Story>();

        List<Story> stories = [];

        while(feed.HasMoreResults)
        {
            var response = await feed.ReadNextAsync(cancellationToken);

            foreach (var story in response)
            {
                stories.Add(story);
            }
        }

        return stories;
    }

    public async Task<Story?> GetStoryAsync(string storyId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(storyId, nameof(storyId));

        var queryable = _db.StoriesContainer.GetItemLinqQueryable<Story>();

        var matches = queryable
            .Where(s => s.Id == storyId);

        using var feed = matches.ToFeedIterator<Story>();

        List<Story> stories = [];

        while (feed.HasMoreResults)
        {
            var response = await feed.ReadNextAsync(cancellationToken);

            foreach (var story in response)
            {
                return story;
            }
        }

        return null;
    }

    public Task<IReadOnlyList<int>> GetStoryMonthsAsync(int year)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<int>> GetStoryYearsAsync()
    {
        throw new NotImplementedException();
    }
}
