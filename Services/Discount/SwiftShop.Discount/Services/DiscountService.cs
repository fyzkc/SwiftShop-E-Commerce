using Dapper;
using SwiftShop.Discount.Context;
using SwiftShop.Discount.Dtos;

namespace SwiftShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;

        public DiscountService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateCouponAsync(CreateCouponDto createdCoupon)
        {
            string insertQuery = "Insert into Coupons(Code,Rate,IsActive,ValidDate) Values(@code,@rate,@isActive,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createdCoupon.Code);
            parameters.Add("@rate", createdCoupon.Rate);
            parameters.Add("@isActive", createdCoupon.IsActive);
            parameters.Add("@validDate", createdCoupon.ValidDate);
            using(var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(insertQuery, parameters);
            }
        }

        public async Task DeleteCouponAsync(int couponId)
        {
            string deleteQuery = "Delete From Coupons Where CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", couponId);
            using(var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(deleteQuery, parameters);
            }
        }

        public async Task<List<ResultCouponDto>> GetAllCouponsAsync()
        {
            string selectAllQuery = "Select * From Coupons";
            using(var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCouponDto>(selectAllQuery);
                return values.ToList();
            }
        }

        public async Task<ResultCouponDto> GetCouponByIdAsync(int couponId)
        {
            string selectByIdQuery = "Select * From Coupons Where CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", couponId);
            using(var connection = _dapperContext.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<ResultCouponDto>(selectByIdQuery);
                return value;
            }
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updatedCoupon)
        {
            string updateQuery = "Update Coupons Set Code=@code, Rate=@rate, IsActive=@isActive, ValidDate=@validDate Where CouponId= @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@code", updatedCoupon.Code);
            parameters.Add("@rate", updatedCoupon.Rate);
            parameters.Add("@isActive", updatedCoupon.IsActive);
            parameters.Add("@validDate", updatedCoupon.ValidDate);
            parameters.Add("@couponId", updatedCoupon.CouponId);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(updateQuery, parameters);
            }
        }
    }
}
