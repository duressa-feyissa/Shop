using Basket.Application.Responses;
using Basket.Core.Entities;
using MediatR;

namespace Basket.Application.Commands;

public class CreateShoppingCartCommand : IRequest<ShoppingCartResponse>
{
    public required string UserName { get; set; }
    public required List<ShoppingCartItem> Items { get; set; }
}