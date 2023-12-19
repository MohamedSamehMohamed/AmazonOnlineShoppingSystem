using Application.Authentication;
using Application.Services.Authentication;
using Application.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;
[ApiController]
[Route("auth")]
public class AuthenticationController: ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IMediator _sender;
    public AuthenticationController(IAuthenticationService authenticationService, IMediator sender)
    {
        _authenticationService = authenticationService;
        _sender = sender;
    }

    private AuthenticationResponse _getResponse(AuthenticationResult result)
    {
        var response = result.Succeeded
            ? new AuthenticationResponse(result.Id, result.Token, result.ExpireOn, true, new List<string>())
            : new AuthenticationResponse("", "", result.ExpireOn, false, result.Errors);
        return response;
    }
    [HttpPost]
    /// register then login 
    public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationCommand userRegistrationCommand)
    {
        try
        {
            var registerResponse = await _sender.Send(userRegistrationCommand);
            if (!registerResponse.Succeed)
                return BadRequest(registerResponse.Errors);
            return await Login(new LoginRequest(userRegistrationCommand.Email, userRegistrationCommand.Password));
        }
        catch (Exception exception)
        {
            if (exception.Message.Contains("SqlException"))
                return BadRequest("Error In The Database");
            return BadRequest(exception.Message);
        }
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        try
        {
            var result = await _authenticationService.Login(request.Email, request.Password);
            var response = _getResponse(result);
            return Ok(response);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }
}