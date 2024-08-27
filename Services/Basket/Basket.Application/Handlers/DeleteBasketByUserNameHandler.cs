using Basket.Application.Queries;
using Basket.Core.Repositories;
using MediatR;

namespace Basket.Application.Handlers;

public class DeleteBasketByUserNameHandler(IBasketRepository basketRepository)
    : IRequestHandler<DeleteBasketByUserNameQuery, bool>
{
    public async Task<bool> Handle(DeleteBasketByUserNameQuery request, CancellationToken cancellationToken)
    {
        var result = await basketRepository.DeleteBasket(request.UserName);
        return result;
    }
}