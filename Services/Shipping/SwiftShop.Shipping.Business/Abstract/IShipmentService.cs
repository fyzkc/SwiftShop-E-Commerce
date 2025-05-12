using SwiftShop.Shipping.Dto.Dtos.Shipment;
using SwiftShop.Shipping.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Shipping.Business.Abstract
{
    public interface IShipmentService : IGenericService<Shipment,CreateShipmentDto,UpdateShipmentDto,ListShipmentDto>
    {
    }
}