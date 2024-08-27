namespace Basket.Application.Responses;

public class ShoppingCartItemResponse
{
    public int Quantity { get; set; }
    public required string ImageFile { get; set; }
    public decimal Price { get; set; }
    public required string ProductId { get; set; }
    public required string ProductName { get; set; }
}