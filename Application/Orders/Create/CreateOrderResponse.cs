namespace Application.Orders.Create;

public record CreateOrderResponse(string OrderId, bool Succeed, List<string> Errors);