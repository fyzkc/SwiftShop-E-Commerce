﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Order.Application.Features.Results.AddressResults
{
    public class GetAddressByIdQueryResult 
    {
        public int AddressId { get; set; }
        public string UserId { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string AddressDetails { get; set; }
    }
}
