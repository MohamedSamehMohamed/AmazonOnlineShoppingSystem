using Domain.Orders;

namespace Application.Dto.Orders;

public record CartItemDTO(string ProductId, int Quantity);
public record CreateOrderDTO(List<CartItemDTO> CartItems, PaymentMethod PaymentMethod);
