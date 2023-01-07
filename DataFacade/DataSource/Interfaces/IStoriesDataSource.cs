using DataFacade.Models.Stories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFacade.DataSource.Interfaces
{
    public interface IStoriesDataSource
    {
        Task<Collection<Story>> GetStoriesByDateAsync(int page, int numberRows);
        Task<Collection<Story>> GetStoriesAsync(int year, int month);
        Task<Story> GetStoryAsync(string storyId);
        Task<Collection<int>> GetStoryYearsAsync();
        Task<Collection<int>> GetStoryMonthsAsync(int year);
        //Data.StoryAttachment GetAttachment(int attachmentId);
        //IEnumerable<Data.StoryAttachment> GetAttachments(int storyId);
    }
}
