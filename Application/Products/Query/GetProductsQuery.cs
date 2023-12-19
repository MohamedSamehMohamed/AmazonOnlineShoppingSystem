using Domain.Products;
using MediatR;

namespace Application.Products.Query;

public record GetProductsQuery(int pageNumber): IRequest<List<Product>>;