using MediatR;
using SwiftShop.Order.Application.Features.Mediator.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Order.Application.Features.Mediator.Queries
{
    //this class is the requesting class and it returns a value.
    public class GetOrderingQuery : IRequest<List<GetOrderingQueryResult>> //this class will return a List of GetOrderingQueryResult
        //because of it returns all the data, it doesn't take any parameters. So that the class is empty.
    {
    }
}
