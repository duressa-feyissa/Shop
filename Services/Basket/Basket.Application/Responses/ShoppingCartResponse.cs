namespace Basket.Application.Responses;

public class ShoppingCartResponse
{
    public required string UserName { get; set; }
    public required List<ShoppingCartItemResponse> Items { get; set; }

    public decimal TotalPrice
    {
        get
        {
            decimal totalPrice = 0;
            foreach (var item in Items)
            {
                totalPrice += item.Price * item.Quantity;
            }

            return totalPrice;
        }
    }
}