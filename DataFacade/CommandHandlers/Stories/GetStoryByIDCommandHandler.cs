using DataFacade.DataSource.Interfaces;
using DataFacade.DataSource;
using DataFacade.Commands.Stories;
using DataFacade.Models.Stories;
using System.Threading;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFacade.CommandHandlers.Stories;

public static class GetStoryByIdCommandHandler
{
    public static async Task<Story?> Handle(GetStoryByIdCommand request, IStoriesDataSource dataSource,
        CancellationToken cancellationToken)
    {
        return await dataSource.GetStoryAsync(request.StoryId, cancellationToken);
    }
}
