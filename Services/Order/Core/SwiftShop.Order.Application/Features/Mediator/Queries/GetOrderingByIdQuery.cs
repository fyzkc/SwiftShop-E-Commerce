using MediatR;
using SwiftShop.Order.Application.Features.Mediator.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Order.Application.Features.Mediator.Queries
{
    public class GetOrderingByIdQuery : IRequest<GetOrderingByIdQueryResult> //this class will return only one data, so that it takes an parameter.
    {
        public int OrderingId { get; set; }

        public GetOrderingByIdQuery(int orderingId)
        {
            OrderingId = orderingId;
        }
    }
}
