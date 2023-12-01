using Application.Authentication;
using Application.Services.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;
[ApiController]
[Route("auth")]
public class AuthenticationController: ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    private AuthenticationResponse _getResponse(AuthenticationResult result)
    {
        var response = result.Succeeded
            ? new AuthenticationResponse(result.Id, result.Token, result.ExpireOn, true, new List<string>())
            : new AuthenticationResponse("", "", result.ExpireOn, false, result.Errors);
        return response;
    }
    [HttpPost("register")]
    public async Task<OkObjectResult> Register(RegisterRequest request)
    {
        var result = await _authenticationService.Register(request.Email,request.Password);
        var response = _getResponse(result);
        // TODO create user profile 
        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var result = await _authenticationService.Login(request.Email, request.Password);
        var response = _getResponse(result);
        return Ok(response);
    }
}