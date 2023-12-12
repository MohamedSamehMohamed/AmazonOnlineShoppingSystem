using Application.Data;
using Domain.Orders;
using MediatR;

namespace Application.Orders.Create;

public class CreateOrderCommandHandler: IRequestHandler<CreateOrderCommand, string>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateOrderCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<string> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            UserId = request.UserId,
            CartItems = request.CartItems,
            TimeOfOrder = DateTime.Now,
            PaymentMethod = request.PaymentMethod,
            OrderStatus = request.OrderStatus
        };
        _unitOfWork.OrderRepository.AddOrder(order);
        return order.OrderId;
    }
}