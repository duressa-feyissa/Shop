using Basket.Application.Responses;
using MediatR;

namespace Basket.Application.Queries;

public class GetBasketByUserNameQuery : IRequest<ShoppingCartResponse>
{
    public required string UserName { get; set; }
}