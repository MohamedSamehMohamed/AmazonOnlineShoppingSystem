using Application.Authentication;
using Application.Data;
using Application.Services.Authentication;
using Domain.Users;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
public class RegisterUserController: ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthenticationService _authenticationService;

    public RegisterUserController(IUnitOfWork unitOfWork, IAuthenticationService authenticationService)
    {
        _unitOfWork = unitOfWork;
        _authenticationService = authenticationService;
    }

    [HttpPost]
    async Task<IActionResult> RegisterUser(UserRegistration userRegistration)
    {
        var result = await _authenticationService.
            Register(userRegistration.Email, userRegistration.Password);
        if (!result.Succeeded)
            return BadRequest(result.Errors);
        var user = new User
        {
            Name = userRegistration.Name,
            AuthenticationId = result.Id
        };
        _unitOfWork.AuthenticatedUser.AddAsync(user);
        return Ok(user.UserId);
    }
}