using System.Diagnostics;
using System.Security.Claims;
using Application.Products.Create;
using Application.Products.DTO;
using Application.Products.Query;
using Infrastructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Presentation.Controllers;


//[HasPermission(Permissions.ReadMember)]
[Authorize]
[ApiController]
[Route("[Controller]")]
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
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductDTO request)
    {
        try
        {
            var authenticationId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var command = new CreateProductCommand(request.Name, request.Description, request.ImageUrl, request.Price,
                request.AvailableItemCount, request.CategoryId, authenticationId);
            
            var response = await _sender.Send(command);
            if (!response.Succeed)
            {
                return BadRequest(response.Errors);
            }
            return Ok(response);
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest();
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
            return BadRequest();
        }
    }
}