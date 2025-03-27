using MediatR;
using SwiftShop.Order.Application.Features.Results.OrderingResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Order.Application.Features.Queries.OrderingQueries
{
    public class GetOrderingByIdQuery : IRequest<GetOrderingByIdQueryResult>
    {
        public int OrderingId { get; set; }

        public GetOrderingByIdQuery(int orderingId)
        {
            OrderingId = orderingId;
        }
    }
}
