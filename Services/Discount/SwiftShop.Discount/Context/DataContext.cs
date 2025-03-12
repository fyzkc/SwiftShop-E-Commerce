using Microsoft.EntityFrameworkCore;
using SwiftShop.Discount.Entities;
using System;
using System.Data.Common;

namespace SwiftShop.Discount.Context
{
    public class DataContext : DbContext //This class is only for making tables on database with migrations. 
    {
        public DbSet<Coupon> Coupons { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
