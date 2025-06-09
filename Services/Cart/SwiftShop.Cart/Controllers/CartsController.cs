using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwiftShop.Cart.Dtos;
using SwiftShop.Cart.Services;
using SwiftShop.Cart.SharedIdentity;

namespace SwiftShop.Cart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ISharedIdentityService _sharedIdentityService;
        private readonly ICartService _cartService;

        public CartsController(ISharedIdentityService sharedIdentityService, ICartService cartService)
        {
            _sharedIdentityService = sharedIdentityService;
            _cartService = cartService;
        }

        //[Authorize(Policy = "CartReadOrFullPolicy")]
        //[HttpGet("whoami")]
        //public IActionResult WhoAmI()
        //{
        //    var claims = User.Claims.Select(c => $"{c.Type} = {c.Value}");
        //    return Ok(claims);
        //}

        [Authorize(Policy = "CartReadOrFullPolicy")]
        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            var userId = _sharedIdentityService.GetUserId();
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var cart = await _cartService.GetCartAsync(userId);
            return cart == null ? NotFound("Cart is empty.") : Ok(cart);
        }


        [Authorize(Policy = "CartFullPolicy")]
        [HttpPost]
        public async Task<IActionResult> SaveOrUpdateCart(TotalItemsDto totalItems)
        {
            var userId = _sharedIdentityService.GetUserId();
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            totalItems.UserId = userId;
            var result = await  _cartService.SaveOrUpdateCartAsync(totalItems);
            return result ? Ok("Cart saved successfully.") : StatusCode(500, "Cart couldn't save.");
        }


        [Authorize(Policy = "CartFullPolicy")]
        [HttpDelete("items/{productId}")]
        public async Task<IActionResult> RemoveItemFromCart(string productId)
        {
            var userId = _sharedIdentityService.GetUserId();
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var result = await _cartService.RemoveItemFromCartAsync(userId, productId);

            if (!result)
                return NotFound("The item couldn't find in cart.");

            return Ok("The item removed from cart successfully.");
        }


        [Authorize(Policy = "CartFullPolicy")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCart()
        {
            var userId = _sharedIdentityService.GetUserId();
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();

            var result = await _cartService.DeleteCartAsync(userId);
            return result ? Ok("Cart is deleted successfully.") : NotFound("Cart is already empty.");
        }
    }
}
