namespace Basket.Core.Entities;

public class ShoppingCart
{
    public required string UserName { get; set; }
    public required List<ShoppingCartItem> Items { get; set; } = new();
}