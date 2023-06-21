using Application.Data;
using Domain.Products;
using MediatR;

namespace Application.Products.Create;

public class CreateProductCommandHandler: IRequestHandler<CreateProductCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(
            request.Name, 
            request.Description, 
            request.ImageUrl, 
            request.Price, 
            request.AvailableItemCount,
            new Category(request.CategoryId));
        
        _unitOfWork.ProductRepository.Add(product);

        await _unitOfWork.SaveChangeAsync();
    }
}