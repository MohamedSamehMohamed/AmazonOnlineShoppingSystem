using Application.Products.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Presentation.Controllers;

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
    public async Task<IActionResult> Product([FromBody] CreateProductCommand command)
    {
        try
        {
            await _sender.Send(command);
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest();
        }
    }
}