using Application.Authentication;
using Application.Data;
using Application.Services.Authentication;
using Application.Users;
using Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("[Controller]")]
public class RegisterUserController: ControllerBase
{
    private readonly IMediator _sender;

    public RegisterUserController(IMediator sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationCommand userRegistrationCommand)
    {
        var registerResponse = await _sender.Send(userRegistrationCommand);
        if (!registerResponse.Succeed)
            return BadRequest(registerResponse.Errors);
        return Ok(registerResponse);
    }
}