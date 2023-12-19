using Domain.Orders;
using MediatR;

namespace Application.Orders.Query;

public record GetOrderByUserQuery(string UserId, int PageNumber): IRequest<IList<Order>>;