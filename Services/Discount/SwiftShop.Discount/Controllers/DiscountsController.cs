using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftShop.Discount.Dtos;
using SwiftShop.Discount.Services;

namespace SwiftShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [Authorize(Policy = "DiscountReadOrFullPolicy")]
        [HttpGet]
        public async Task<IActionResult> GetAllCoupons()
        {
            var coupons = await _discountService.GetAllCouponsAsync();
            return Ok(coupons);
        }

        [Authorize(Policy = "DiscountReadOrFullPolicy")]
        [HttpGet("{couponId}")]
        public async Task<IActionResult> GetCouponById(int couponId)
        {
            var coupon = await _discountService.GetCouponByIdAsync(couponId);
            return Ok(coupon);
        }

        [Authorize(Policy = "DiscountFullPolicy")]
        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CreateCouponDto createCouponDto)
        {
            await _discountService.CreateCouponAsync(createCouponDto);
            return Ok("Coupon created successfully");
        }

        [Authorize(Policy = "DiscountFullPolicy")]
        [HttpPut]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponDto updateCouponDto)
        {
            await _discountService.UpdateCouponAsync(updateCouponDto);
            return Ok("Coupon updated successfully");
        }

        [Authorize(Policy = "DiscountFullPolicy")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCoupon(int couponId)
        {
            await _discountService.DeleteCouponAsync(couponId);
            return Ok("Coupon deleted successfully");
        }
    }
}
