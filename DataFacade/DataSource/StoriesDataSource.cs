using DataFacade.DataSource.Interfaces;
using DataFacade.Models;
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
        private readonly string _connectionString;
        
        public StoriesDataSource(ILogger<StoriesDataSource> logger, string connectionString)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));

            _logger.LogInformation($"{nameof(StoriesDataSource)}()");
        }

        public ReadOnlyCollection<Story> GetStories()
        {
            List<Story> stories = new()
            {
                new Story() { Content = "Hello from NextJS", ID = 1, PublishedDate = DateTime.UtcNow, Title = "First" },
                new Story() { Content = "Hello from TailWind", ID = 2, PublishedDate = DateTime.UtcNow, Title = "Second" }
            };

            _logger.LogInformation($"{nameof(StoriesDataSource)}:{nameof(GetStories)}()");

            return new ReadOnlyCollection<Story>(stories);
        }

        public IEnumerable<Story> GetStories(int year, int month)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Story> GetStoriesByDate(int page, int numberRows)
        {
            throw new NotImplementedException();
        }

        public Story GetStory(string storyId)
        {
            throw new NotImplementedException();
        }

        public int GetStoryCount()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> GetStoryMonths(int year)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> GetStoryYears()
        {
            throw new NotImplementedException();
        }
    }
}
