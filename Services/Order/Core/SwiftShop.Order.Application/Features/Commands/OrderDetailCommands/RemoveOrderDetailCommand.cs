using MediatR;
using SwiftShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Order.Application.Features.Commands.OrderDetailCommands
{
    public class RemoveOrderDetailCommand : IRequest
    {
        public int OrderDetailId { get; set; }

        public RemoveOrderDetailCommand(int orderDetailId)
        {
            OrderDetailId = orderDetailId;
        }
    }
}
