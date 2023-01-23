using DataFacade.Models.Stories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFacade.Commands.Stories;

public class GetStoriesByDateCommand : IRequest<IReadOnlyList<Story>>
{
    public int Page { get; }
    public int NumberRows { get; }

    public GetStoriesByDateCommand(int page, int numberRows) 
    { 
        Page = page;
        NumberRows = numberRows;
    }
}
