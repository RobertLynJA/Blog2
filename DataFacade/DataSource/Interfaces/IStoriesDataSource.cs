using DataFacade.Models;
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
        Task<IEnumerable<Story>> GetStoriesByDateAsync(int page, int numberRows);
        Task<IEnumerable<Story>> GetStoriesAsync(int year, int month);
        Task<Story> GetStoryAsync(string storyId);
        Task<IEnumerable<int>> GetStoryYearsAsync();
        Task<IEnumerable<int>> GetStoryMonthsAsync(int year);
        //Data.StoryAttachment GetAttachment(int attachmentId);
        //IEnumerable<Data.StoryAttachment> GetAttachments(int storyId);
    }
}
