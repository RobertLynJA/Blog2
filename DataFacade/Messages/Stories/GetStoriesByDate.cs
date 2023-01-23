using DataFacade.Models.Stories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFacade.Messages.Stories;

public class GetStoriesByDate : IRequest<IReadOnlyList<Story>>
{
    public int Page { get; }
    public int NumberRows { get; }

    public GetStoriesByDate(int page, int numberRows) 
    { 
        Page = page;
        NumberRows = numberRows;
    }
}
