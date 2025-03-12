using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SwiftShop.Discount.Entities;
using System.Data;

namespace SwiftShop.Discount.Context
{
    public class DapperContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-ES8AIES\\SQLEXPRESS;Initial Catalog=SwiftShopDiscountDb;TrustServerCertificate=True; Integrated Security=True;");
        }

        public DbSet<Coupon> Coupons { get; set; }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
