using DataFacade.DataSource.Interfaces;
using DataFacade.DataSource;
using DataFacade.Messages.Stories;
using DataFacade.Models.Stories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFacade.MessageHandlers.Stories;

public class GetStoryByIDHandler : IRequestHandler<GetStoryByID, Story?>
{
    private readonly ILogger<StoriesDataSource> _logger;
    private readonly IStoriesDataSource _dataSource;

    public GetStoryByIDHandler(ILogger<StoriesDataSource> logger, IStoriesDataSource dataSource)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _dataSource = dataSource ?? throw new ArgumentNullException(nameof(dataSource));
    }

    public async Task<Story?> Handle(GetStoryByID request, CancellationToken cancellationToken)
    {
        return await _dataSource.GetStoryAsync(request.StoryID, cancellationToken);
    }
}
