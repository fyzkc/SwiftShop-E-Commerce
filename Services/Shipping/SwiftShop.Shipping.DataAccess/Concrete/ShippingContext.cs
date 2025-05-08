using Microsoft.EntityFrameworkCore;
using SwiftShop.Shipping.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Shipping.DataAccess.Concrete
{
    public class ShippingContext : DbContext
    {
        public ShippingContext(DbContextOptions<ShippingContext> options)
        : base(options) { }

        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Shipment> Shipments { get; set; }


    }
}
