using DataFacade.Models.Stories;
using MediatR;
using Microsoft.Azure.Cosmos.Serialization.HybridRow.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFacade.Commands.Stories;

public class GetStoryByIDCommand : IRequest<Story?>
{
    public string StoryID { get; }
    
    public GetStoryByIDCommand(string storyID)
    {
        StoryID = storyID ?? throw new ArgumentNullException(storyID);
    }
}
