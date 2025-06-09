using SwiftShop.Cart.Dtos;

namespace SwiftShop.Cart.Services
{
    public interface ICartService
    {
        Task<bool> SaveOrUpdateCartAsync(TotalItemsDto cart);
        Task<TotalItemsDto> GetCartAsync(string userId);
        Task<bool> DeleteCartAsync(string userId);
        Task<bool> RemoveItemFromCartAsync(string userId, string productId);
    }
}
