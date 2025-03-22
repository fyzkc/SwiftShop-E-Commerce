using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Order.Application.Features.CQRS.Commands.AddressCommands
{
    public class RemoveAddressCommand
    {
        public int AddressId { get; set; }
        public RemoveAddressCommand(int addressId)
        {
            AddressId = addressId;
        }
    }
}
