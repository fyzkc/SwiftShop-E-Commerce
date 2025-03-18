using SwiftShop.Discount.Dtos;

namespace SwiftShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetAllCouponsAsync();
        Task<ResultCouponDto> GetCouponByIdAsync(int couponId);
        Task CreateCouponAsync(CreateCouponDto createdCoupon);
        Task UpdateCouponAsync(UpdateCouponDto updatedCoupon);
        Task DeleteCouponAsync(int couponId);
    }
}
