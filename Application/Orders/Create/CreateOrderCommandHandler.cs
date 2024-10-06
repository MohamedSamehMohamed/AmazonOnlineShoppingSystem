using Application.Data;
using Domain.Orders;
using MediatR;

namespace Application.Orders.Create;

public class CreateOrderCommandHandler: IRequestHandler<CreateOrderCommand, CreateOrderResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateOrderCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<CreateOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var order = new Order
            {
                UserId = request.UserId,
                TimeOfOrder = DateTime.Now,
                PaymentMethod = request.PaymentMethod,
                OrderStatus = request.OrderStatus
            };
            foreach (var cart in request.CartItems)
            {
                var product = await _unitOfWork.ProductRepository.GetAsync(cart.ProductId);
                if (product == null)
                    return new CreateOrderResponse("", false,
                        new List<string>() { cart.ProductId + " product id not exist" });
                if (product.AvailableItemCount < cart.Quantity)
                    return new CreateOrderResponse("", false,
                        new List<string>() { "no available quantity of product " + cart.ProductId });
                var discount = _unitOfWork.DiscountRepository.Get(product.ProductId);
                var discountValue = discount?.DiscountPercent?? 0.0;
                order.CartItems.Add(new CartItem(order.OrderId, product.ProductId,
                    cart.Quantity, product.Price * cart.Quantity, discountValue));
                product.AvailableItemCount -= cart.Quantity;
            }

            var addStatus = await _unitOfWork.OrderRepository.AddOrder(order);
            if (!addStatus)
                return new CreateOrderResponse("", false, new List<string>() { "add the order failed" });
            await _unitOfWork.SaveChangeAsync();
            return new CreateOrderResponse(order.OrderId, true, new List<string>());
        }
        catch (Exception exception)
        {
            return new CreateOrderResponse("", false, new List<string>() { "add the order failed" });
        }
    }
}