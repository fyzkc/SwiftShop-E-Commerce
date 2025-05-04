using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Shipping.Entity.Enums
{
    public enum ShipmentStatus
    {
        Created = 0,
        InTransit = 1,
        Delivered = 2,
        Cancelled = 3,
        Returned = 4
    }
}
