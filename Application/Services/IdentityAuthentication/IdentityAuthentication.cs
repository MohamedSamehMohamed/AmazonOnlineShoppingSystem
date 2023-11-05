using Application.Authentication;
using Application.Services.IdentityAuthentication.IdentityModels;
using Microsoft.AspNetCore.Identity;

namespace Application.Services.IdentityAuthentication;

public class IdentityAuthentication: IIdentityAuthentication
{
    private UserManager<IdentityUser> _userManager;

    public IdentityAuthentication(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityResponse> Register(IdentityRequest registerRequest)
    {
        var user = new IdentityUser
        {
            Email = registerRequest.Email,
            UserName = registerRequest.Email
        };
        var result = await _userManager.CreateAsync(user, registerRequest.Password);
        if (!result.Succeeded)
            return new IdentityResponse("", false, result.Errors.Select(e=>e.Description).ToList());
        return new IdentityResponse(user.Id, true, new List<string>());
    }

    public async Task<IdentityResponse> Login(IdentityRequest loginRequest)
    {
        var user = await _userManager.FindByEmailAsync(loginRequest.Email);
        
        if (user == null)
            return new IdentityResponse("", false, new List<string>()
            {
                "email or/and password  are wrong"
            });
        var result = await _userManager.CheckPasswordAsync(user, loginRequest.Password);
        if (result)
            return new IdentityResponse(user.Id, true, new List<string>());
        return new IdentityResponse("", false, new List<string>()
        {
            "email or/and password  are wrong"
        });
    }
}