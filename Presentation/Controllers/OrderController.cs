using System.Security.Claims;
using Application.Data;
using Application.Dto.Orders;
using Application.Orders.Create;
using Application.Orders.Query;
using Domain.Orders;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Presentation.Controllers;

[ApiController]
[Route("[Controller]/[action]")]
[Authorize]
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
    public async Task<IActionResult> GetOrders([FromQuery] int pageNumber)
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var query = new GetOrderByUserQuery(userId, pageNumber);
            var orders = await _sender.Send(query);
            return Ok(orders);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception.Message);
            return BadRequest(exception.Message);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetOrdersByUser([FromQuery] string userId)
    {
        try
        {
            var order = await _sender.Send(userId);
            return Ok(order);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception.Message);
            return BadRequest(exception.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddOrder([FromBody] CreateOrderDTO request)
    {
        try
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var command =
                new CreateOrderCommand(userId, request.CartItems, OrderStatus.InProcess, request.PaymentMethod);
            var orderId = await _sender.Send(command);
            return Ok(orderId);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception.Message);
            return BadRequest(exception.Message);
        }
    }
}