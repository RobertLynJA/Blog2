using DataFacade.DataSource;
using DataFacade.DataSource.Interfaces;
using DataFacade.DB;
using DataFacade.Commands.Stories;
using DataFacade.Models.Stories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFacade.CommandHandlers.Stories;

public class GetStoriesByDateCommandHandler : IRequestHandler<GetStoriesByDateCommand, IReadOnlyList<Story>>
{
    private readonly ILogger<GetStoriesByDateCommandHandler> _logger;
    private readonly IStoriesDataSource _dataSource;

    public GetStoriesByDateCommandHandler(ILogger<GetStoriesByDateCommandHandler> logger, IStoriesDataSource dataSource)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _dataSource = dataSource ?? throw new ArgumentNullException(nameof(dataSource));
    }

    public async Task<IReadOnlyList<Story>> Handle(GetStoriesByDateCommand request, CancellationToken cancellationToken)
    {
        return await _dataSource.GetStoriesByDateAsync(request.Page, request.NumberRows, cancellationToken);
    }
}
