using Application.Common.Interfaces;
using Application.Services.IdentityAuthentication;
using Application.Services.IdentityAuthentication.IdentityModels;
using Infrastructure.Authentication;

namespace Application.Services.Authentication;

public class AuthenticationService: IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IIdentityAuthentication _identityAuthentication;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IIdentityAuthentication identityAuthentication)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _identityAuthentication = identityAuthentication;
    }

    private JwtResponse _getJwtResponse(string userId, string email)
    {
        var token = _jwtTokenGenerator.GenerateToken(new JwtUserModel(userId, email));
        return token;
    }

    private AuthenticationResult _handleResponse(IdentityResponse user, string email)
    {
        if (!user.Succeeded)
            return new AuthenticationResult("", "", null,false, user.Errors);
        var jwtResponse = _getJwtResponse(user.Id, email);
        return new AuthenticationResult(user.Id,jwtResponse.Token, jwtResponse.ExpireOn, true, new List<string>());
    }
    public async Task<AuthenticationResult> Register(string email, string password)
    {
        var user = await _identityAuthentication.Register(new IdentityRequest(email, password));
        return _handleResponse(user, email);
    }
    public async Task<AuthenticationResult> Login(string email, string password)
    {
        var user = await _identityAuthentication.Login(new IdentityRequest(email, password));
        return _handleResponse(user, email);
    }
}