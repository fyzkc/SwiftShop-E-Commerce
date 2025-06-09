using StackExchange.Redis;
using SwiftShop.Cart.Dtos;
using SwiftShop.Cart.Settings;
using System.Text.Json;

namespace SwiftShop.Cart.Services
{
    public class CartService : ICartService
    {
        private readonly RedisService _redisService;
        private readonly IDatabase _database;

        public CartService(RedisService redisService)
        {
            _redisService = redisService;
            _database = _redisService.GetDb();
        }

        public async Task<TotalItemsDto> GetCartAsync(string userId)
        {
            var cart = await _database.StringGetAsync(userId);
            // with this line we are trying to get the data that the key value is userId.
            // StringGetAsync() is a Redis method. And its used for getting a string value. 
            // the datas has saved as JSON format. So that we should get it as string.

            if (string.IsNullOrEmpty(cart)) return null;
            // if there is no data on Redis, then it should return null.

            return JsonSerializer.Deserialize<TotalItemsDto>(cart);
            // if there are some data on Redis, then we should change its format from JSON to TotalItemsDto.
            // with this line we are converting it to a C# object.
            // after changing the format, it returns the new value. 
        }

        //NOTE: Serialize means turning a Dto object into a JSON object.
        //      Deserialize means turning a JSON object into a DTO object. 

        public async Task<bool> SaveOrUpdateCartAsync(TotalItemsDto cart)
        {
            var jsonItem = JsonSerializer.Serialize(cart);
            // it turns the TotalItemsDto object into the JSON object and assigning it to the jsonItem object.

            return await _database.StringSetAsync(cart.UserId, jsonItem);
            // StringSetAsync() is a Redis method
            // It stores the JSON string in Redis using the user's ID as the key.
            // If a value already exists for this key, it will be overwritten.
        }

        public async Task<bool> RemoveItemFromCartAsync(string userId, string productId)
        {
            var cart = await GetCartAsync(userId);
            if(cart == null) return false;

            var itemToRemove = cart.Items.FirstOrDefault(x => x.ProductId == productId);
            if (itemToRemove == null) return false;

            cart.Items.Remove(itemToRemove);
            //we are not making it async because it's just a list operation.
            //it doesn't make an interaction with any outer sources. 
            //so that we are making it sync.

            return await SaveOrUpdateCartAsync(cart);
        }

        public async Task<bool> DeleteCartAsync(string userId)
        {
            return await _database.KeyDeleteAsync(userId);
            // KeyDeleteAsync is a Redis method and it deletes the data that has the key value of userId.
        }

        
    }
}
