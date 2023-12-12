using Domain.Products;
using MediatR;

namespace Application.Products.Query;

public record GetProductQuery(string ProductId): IRequest<Product?>;