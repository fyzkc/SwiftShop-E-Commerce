using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Shipping.Dto.Dtos.Carrier
{
    public class UpdateCarrierDto
    {
        public int CarrierId { get; set; }
        public string CarrierName { get; set; }
    }
}
