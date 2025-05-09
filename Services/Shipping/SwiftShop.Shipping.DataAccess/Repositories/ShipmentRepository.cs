using SwiftShop.Shipping.DataAccess.Abstract;
using SwiftShop.Shipping.DataAccess.Concrete;
using SwiftShop.Shipping.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Shipping.DataAccess.Repositories
{
    public class ShipmentRepository : GenericRepository<Shipment>, IShipmentRepository
    {
        public ShipmentRepository(ShippingContext shippingContext) : base(shippingContext)
        {
            
        }
    }
}
