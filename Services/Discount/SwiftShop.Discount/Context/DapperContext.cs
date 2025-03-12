using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SwiftShop.Discount.Entities;
using System.Data;

namespace SwiftShop.Discount.Context
{
    public class DapperContext // This class is for making data processes with Dapper
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }       
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
