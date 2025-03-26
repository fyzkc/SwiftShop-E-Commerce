using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands
{
    public class RemoveOrderDetailCommand
    {
        public int OrderDetailId { get; set; }
        public RemoveOrderDetailCommand(int orderDetailId)
        {
            OrderDetailId = orderDetailId;
        }
    }
}
