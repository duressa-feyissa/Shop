using Basket.Core.Entities;

namespace Basket.Core.Repositories;

public abstract class IBasketRepository
{
    public abstract Task<ShoppingCart> GetBasket(string userName);
    public abstract Task<ShoppingCart> UpdateBasket(ShoppingCart basket);
    public abstract Task<bool> DeleteBasket(string userName);
}