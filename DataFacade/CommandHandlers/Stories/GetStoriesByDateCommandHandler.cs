using DataFacade.DataSource;
using DataFacade.DataSource.Interfaces;
using DataFacade.DB;
using DataFacade.Commands.Stories;
using DataFacade.Models.Stories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFacade.CommandHandlers.Stories;

public static class GetStoriesByDateCommandHandler
{
    public static async Task<IReadOnlyList<Story>> Handle(GetStoriesByDateCommand request, IStoriesDataSource dataSource, CancellationToken cancellationToken)
    {
        return await dataSource.GetStoriesByDateAsync(request.Page, request.NumberRows, cancellationToken);
    }
}
