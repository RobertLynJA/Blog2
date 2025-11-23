using DataFacade.Models.Stories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFacade.Commands.Stories;

public class GetStoryByIdCommand
{
    public string StoryId { get; }
    
    public GetStoryByIdCommand(string storyId)
    {
        StoryId = storyId ?? throw new ArgumentNullException(storyId);
    }
}
