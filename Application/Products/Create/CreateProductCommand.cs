using Domain.Products;
using MediatR;
namespace Application.Products.Create;

public record CreateProductCommand(
    string Name, 
    string Description, 
    string ImageUrl, 
    double Price, 
    int AvailableItemCount, 
    int CategoryId): IRequest;