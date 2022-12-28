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
        ReadOnlyCollection<Story> GetStories();
    }
}
