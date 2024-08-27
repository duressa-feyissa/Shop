using System.Text.Json;
using Basket.Core.Entities;
using Basket.Core.Repositories;
using Microsoft.Extensions.Caching.Distributed;

namespace Basket.Infrastructure.Repositories;

public class BasketRepository(IDistributedCache redisCache) : IBasketRepository
{
    
    public  override async Task<ShoppingCart> GetBasket(string userName)
    {
        var basket = await redisCache.GetStringAsync(userName);
        if (string.IsNullOrEmpty(basket))
        {
            return null;
        }
        return JsonSerializer.Deserialize<ShoppingCart>(basket)!;
    }

    public override async Task<ShoppingCart> UpdateBasket(ShoppingCart shoppingCart)
    {
        await redisCache.SetStringAsync(shoppingCart.UserName, JsonSerializer.Serialize(shoppingCart));
        return await GetBasket(shoppingCart.UserName);
    }

    public override async Task<bool> DeleteBasket(string userName)
    {
        await redisCache.RemoveAsync(userName);
        return true;
    }
}