using SwiftShop.Shipping.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Shipping.Dto.Dtos.Shipment
{
    public class UpdateShipmentDto
    {
        public int ShipmentId { get; set; }
        public int CompanyId { get; set; }
        public string UserId { get; set; }
        public int BarcodeNumber { get; set; }
        public int CarrierId { get; set; }
        public DateTime ShipmentDate { get; set; }
        public DateTime DeliveredDate { get; set; }
        public ShipmentStatus Status { get; set; }
    }
}
