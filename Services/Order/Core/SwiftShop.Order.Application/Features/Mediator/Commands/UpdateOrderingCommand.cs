using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Order.Application.Features.Mediator.Commands
{
    public class UpdateOrderingCommand : IRequest
    {
        public int OrderingId { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
