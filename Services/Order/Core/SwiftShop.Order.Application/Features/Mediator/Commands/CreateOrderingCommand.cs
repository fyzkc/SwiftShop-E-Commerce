using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Order.Application.Features.Mediator.Commands
{
    public class CreateOrderingCommand : IRequest //it doesnt return a value, so that it only implements IRequest.
    {
        public string UserId { get; set; } 
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
