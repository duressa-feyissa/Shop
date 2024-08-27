using MediatR;

namespace Basket.Application.Queries;

public class DeleteBasketByUserNameQuery : IRequest<bool>   
{
    public required string UserName { get; set; }
}