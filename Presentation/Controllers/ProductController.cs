using System.Security.Claims;
using Application.Products.Create;
using Application.Dto.Products;
using Application.Products.Query;
using Infrastructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Presentation.Controllers;


[HasPermission(Permissions.ReadMember)]
[ApiController]
[Route("[Controller]/[action]")]
public class ProductController: ControllerBase
{
    private readonly IMediator _sender;
    private readonly ILogger<ProductController> _logger;
    public ProductController(IMediator sender, ILogger<ProductController> logger)
    {
        _sender = sender;
        _logger = logger;
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto request)
    {
        try
        {
            var userId = User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            this.ThrowIfNull(userId, nameof(userId));
            var command = new CreateProductCommand(request.Name, request.Description, request.ImageUrl, request.Price,
                request.AvailableItemCount, request.CategoryId, userId!);
            _logger.LogInformation($"Command for adding new product: {JsonConvert.SerializeObject(command)}");
            var response = await _sender.Send(command);
            _logger.LogInformation($"Response for Adding new Product: {JsonConvert.SerializeObject(response)}");
            return Ok(response);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetProduct([FromQuery] GetProductQuery query)
    {
        try
        {
            var product = await _sender.Send(query);
            return product == null ? Ok("Not Found") : Ok(product);
        }
        catch(Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }
    [HttpGet]
    public async Task<IActionResult> GetProducts([FromQuery] GetProductsQuery query)
    {
        try
        {
            var products = await _sender.Send(query);
            return Ok(products);
        }
        catch(Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e.Message);
        }
    }

    private void ThrowIfNull(object? obj, string paramName)
    {
        if (obj != null) return;
        _logger.LogError($"paramName: {paramName} is null");
        throw new ArgumentNullException(paramName);
    }
}