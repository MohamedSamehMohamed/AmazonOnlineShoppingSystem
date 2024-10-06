using Application.Data;
using Application.Data.MockRepositories;
using Application.Data.Repositories;
using Application.Products.Create;
using Domain.Products;
using FluentAssertions;
using Moq;


namespace UnitTest.Product.Create;

public class CreateProductHandlerTests
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateProductHandlerTests()
    {
        _unitOfWork = new MockUnitOfwork();
    }

    [Fact]
    public async Task Handle_Should_ReturnFailure_WhenCategory_NotExist()
    {
        var command = new CreateProductCommand("p1", "p1 description", "NA", 1.2, 1, "nonFaildCategoryId", "CreatorId");
        
        var handler = new CreateProductCommandHandler(_unitOfWork);
        var result = await handler.Handle(command, default);
        
        result.Succeed.Should().BeFalse();
    }
}