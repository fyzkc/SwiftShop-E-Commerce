﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Order.Application.Features.Commands.AddressCommands
{
    public class RemoveAddressCommand : IRequest
    {
        public int AddressId { get; set; }

        public RemoveAddressCommand(int addressId)
        {
            AddressId = addressId;
        }
    }
}
