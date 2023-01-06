using DataFacade.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataFacade.DataSource.Interfaces
{
    public interface IStoriesDataSource
    {
        ReadOnlyCollection<Story> GetStories();

        IEnumerable<Story> GetStoriesByDate(int page, int numberRows);
        IEnumerable<Story> GetStories(int year, int month);
        Story GetStory(string storyId);
        int GetStoryCount();
        IEnumerable<int> GetStoryYears();
        IEnumerable<int> GetStoryMonths(int year);
        //Data.StoryAttachment GetAttachment(int attachmentId);
        //IEnumerable<Data.StoryAttachment> GetAttachments(int storyId);
    }
}
