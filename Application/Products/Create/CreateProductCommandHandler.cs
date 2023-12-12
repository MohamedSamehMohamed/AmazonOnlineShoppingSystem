using Application.Data;
using Domain.Products;
using MediatR;

namespace Application.Products.Create;

public class CreateProductCommandHandler: IRequestHandler<CreateProductCommand, string>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<string> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.CategoryRepository.Get(request.CategoryId);
        if (category == null) return "";
        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            ImageUrl = request.ImageUrl,
            Price = request.Price,
            AvailableItemCount = request.AvailableItemCount,
            ProductOwner = request.OwnerId,
            CategoryId = request.CategoryId
        };
        await  _unitOfWork.ProductRepository.AddAsync(product);
        await _unitOfWork.SaveChangeAsync();
        return product.ProductId.ToString();
    }
}