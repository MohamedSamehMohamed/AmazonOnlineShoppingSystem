using Domain.Orders;
using MediatR;

namespace Application.Orders.Create;

public record CreateOrderCommand
    (
        string UserId, 
        List<CartItem> CartItems, 
        OrderStatus OrderStatus, 
        PaymentMethod PaymentMethod
    ): IRequest<string>;