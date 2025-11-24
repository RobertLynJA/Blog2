using DataFacade.Models.Stories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataFacade.Commands.Stories;

public class GetStoriesByDateCommand
{
    public int Page { get; }
    public int PageSize { get; }

    public GetStoriesByDateCommand(int page, int pageSize) 
    { 
        Page = page;
        PageSize = pageSize;
    }
}
