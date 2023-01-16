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
        Task<IReadOnlyList<Story>> GetStoriesByDateAsync(int page, int numberRows);
        Task<IReadOnlyList<Story>> GetStoriesAsync(int year, int month);
        Task<Story?> GetStoryAsync(string storyId);
        Task<IReadOnlyList<int>> GetStoryYearsAsync();
        Task<IReadOnlyList<int>> GetStoryMonthsAsync(int year);
        //Data.StoryAttachment GetAttachment(int attachmentId);
        //IEnumerable<Data.StoryAttachment> GetAttachments(int storyId);
    }
}
