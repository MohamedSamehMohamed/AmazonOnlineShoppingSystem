using Domain.Orders;

namespace Application.Dto.Orders;

public record CreateOrderDTO(List<CartItem> CartItems, PaymentMethod PaymentMethod);