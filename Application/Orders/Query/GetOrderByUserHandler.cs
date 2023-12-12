using Application.Data;
using Domain.Orders;
using MediatR;

namespace Application.Orders.Query;

public class GetOrderByUserHandler: IRequestHandler<GetOrderByUserQuery ,IList<Order>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetOrderByUserHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IList<Order>> Handle(GetOrderByUserQuery request, CancellationToken cancellationToken)
    {
        return  _unitOfWork.OrderRepository.GetOrderByUser(request.UserId);
    }
}