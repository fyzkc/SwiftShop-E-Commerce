using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Order.Application.Features.CQRS.Commands.AddressCommands
{
    public class CreateAddressCommand //If there is any parameters for writing processes, this parameters are defining in Commands folder. 
        //command classes includes the data for creating, updating and deleting processes. 

    {
        public string UserId { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string AddressDetails { get; set; }
    }
}
