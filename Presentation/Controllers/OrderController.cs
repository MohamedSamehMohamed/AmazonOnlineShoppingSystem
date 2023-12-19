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
    private readonly string _userId;
    public OrderController(IMediator sender, ILogger<OrderController> logger)
    {
        _sender = sender;
        _logger = logger;
        _userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders([FromQuery] int pageNumber)
    {
        try
        {
            var query = new GetOrderByUserQuery(_userId, pageNumber);
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
            var command =
                new CreateOrderCommand(_userId, request.CartItems, OrderStatus.InProcess, request.PaymentMethod);
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