using Application.Dto.Orders;
using Domain.Orders;
using MediatR;

namespace Application.Orders.Create;

public record CreateOrderCommand
    (
        string UserId, 
        List<CartItemDTO> CartItems, 
        OrderStatus OrderStatus, 
        PaymentMethod PaymentMethod
    ): IRequest<CreateOrderResponse>;