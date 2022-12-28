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
        private readonly BlogContext _blogContext;

        public StoriesDataSource(ILogger<StoriesDataSource> logger, BlogContext blogContext)
        {
            _logger = logger;
            _blogContext = blogContext;
        }

        public ReadOnlyCollection<Story> GetStories()
        {
            List<Story> stories = new();
            stories.Add(new Story() { Content = "Hello from NextJS", ID = 1, PublishedDate = DateTime.UtcNow, Title = "First" });
            stories.Add(new Story() { Content = "Hello from TailWind", ID = 2, PublishedDate = DateTime.UtcNow, Title = "Second" });

            return new ReadOnlyCollection<Story>(stories);
        }
    }
}
