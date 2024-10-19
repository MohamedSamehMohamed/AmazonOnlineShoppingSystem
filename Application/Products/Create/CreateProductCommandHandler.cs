using Application.Data;
using Domain.Products;
using Domain.Users;
using MediatR;

namespace Application.Products.Create;

public class CreateProductCommandHandler: IRequestHandler<CreateProductCommand, CreateProductResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateProductCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var category = await _unitOfWork.CategoryRepository.Get(request.CategoryId);
            if (category == null)
                return Dto.NotFoundCategory(request.CategoryId);
            
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                Price = request.Price,
                AvailableItemCount = request.AvailableItemCount,
                CategoryId = request.CategoryId,
                ProductOwner = request.CreatorId
            };
            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.SaveChangeAsync();
            return new CreateProductResponse(product.ProductId, true, new List<string>());

        }
        catch (Exception exception)
        {
            return Dto.FailedToAddProduct(exception.Message);
        }
    }
}