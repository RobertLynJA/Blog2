using DataFacade.DataSource.Interfaces;
using DataFacade.DataSource;
using DataFacade.Commands.Stories;
using DataFacade.Models.Stories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFacade.CommandHandlers.Stories;

public class GetStoryByIDCommandHandler : IRequestHandler<GetStoryByIDCommand, Story?>
{
    private readonly ILogger<GetStoryByIDCommandHandler> _logger;
    private readonly IStoriesDataSource _dataSource;

    public GetStoryByIDCommandHandler(ILogger<GetStoryByIDCommandHandler> logger, IStoriesDataSource dataSource)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _dataSource = dataSource ?? throw new ArgumentNullException(nameof(dataSource));
    }

    public async Task<Story?> Handle(GetStoryByIDCommand request, CancellationToken cancellationToken)
    {
        return await _dataSource.GetStoryAsync(request.StoryID, cancellationToken);
    }
}
