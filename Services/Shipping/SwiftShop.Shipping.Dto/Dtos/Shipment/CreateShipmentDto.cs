using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftShop.Shipping.Entity.Entities;
using SwiftShop.Shipping.Entity.Enums;

namespace SwiftShop.Shipping.Dto.Dtos.Shipment
{
    public class CreateShipmentDto
    {
        public int CompanyId { get; set; }
        public string UserId { get; set; }
        public int BarcodeNumber { get; set; }
        public int CarrierId { get; set; }
        public DateTime ShipmentDate { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public ShipmentStatus Status { get; set; }
    }
}
