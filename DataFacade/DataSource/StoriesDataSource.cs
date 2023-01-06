using DataFacade.DataSource.Interfaces;
using DataFacade.DB;
using DataFacade.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFacade.DataSource
{
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

        public Task<IEnumerable<Story>> GetStoriesAsync(int year, int month)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Story>> GetStoriesByDateAsync(int page, int numberRows)
        {
            Container container = _db.StoriesContainer;

            var queryable = container.GetItemLinqQueryable<Story>();

            var matches = queryable
                .OrderByDescending(s => s.PublishedDate)
                .Skip(page * numberRows)
                .Take(numberRows);

            using var feed = matches.ToFeedIterator<Story>();

            List<Story> stories = new();

            while(feed.HasMoreResults)
            {
                var response = await feed.ReadNextAsync();

                foreach (var story in response)
                {
                    stories.Add(story);
                }
            }

            return stories;
        }

        public Task<Story> GetStoryAsync(string storyId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<int>> GetStoryMonthsAsync(int year)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<int>> GetStoryYearsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
