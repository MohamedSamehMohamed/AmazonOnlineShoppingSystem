using Application.Data;
using Application.Orders.Create;
using Domain.Orders;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Presentation.Controllers;

[ApiController]
[Route("[Controller]/[action]")]
public class OrderController: ControllerBase
{
    private readonly IMediator _sender;
    private readonly ILogger<OrderController> _logger;
    public OrderController(IMediator sender, ILogger<OrderController> logger)
    {
        _sender = sender;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetOrders()
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    public async Task<IActionResult> GetOrdersByUser([FromQuery] string userId)
    {
        var order = await _sender.Send(userId);
        return Ok(order);
    }

    [HttpPost]
    public async Task<IActionResult> AddOrder([FromBody] CreateOrderCommand command)
    {
        var orderId = await _sender.Send(command);
        return Ok(orderId);
    }
}