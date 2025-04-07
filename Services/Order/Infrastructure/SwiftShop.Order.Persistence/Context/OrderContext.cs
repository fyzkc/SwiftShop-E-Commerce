using Microsoft.EntityFrameworkCore;
using SwiftShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftShop.Order.Persistence.Context
{
    public class OrderContext : DbContext
    {
        //DbContextOptions is a class that holds configuration settings for the DbContext. 
        //This constructor takes a parameter of type DbContextOptions<OrderContext>. 
        //The 'base(options)' call passes these options to the base DbContext class.
        //The options are configured in Program.cs using the AddDbContext method.

        //When a class needs an instance of OrderContext, the DI (Dependency Injection) system will inject it automatically. 
        //During injection, this constructor runs and uses the options from Program.cs.
        //As a result, a new instance of OrderContext is created with the necessary configuration to connect to the database.
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Ordering> Orderings { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
