using Application.Data;
using Domain.Products;
using MediatR;

namespace Application.Products.Query;

public class GetProductsQueryHandler: IRequestHandler<GetProductsQuery, List<Product>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetProductsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.ProductRepository.GetProducts();
    }
}