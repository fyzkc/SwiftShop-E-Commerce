using MediatR;
using SwiftShop.Order.Application.Features.Results.OrderDetailResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Order.Application.Features.Queries.OrderDetailQueries
{
    public class GetOrderDetailByIdQuery : IRequest<GetOrderDetailByIdQueryResult>
    {
        public int OrderDetailId { get; set; }

        public GetOrderDetailByIdQuery(int orderDetailId)
        {
            OrderDetailId = orderDetailId;
        }
    }
}
