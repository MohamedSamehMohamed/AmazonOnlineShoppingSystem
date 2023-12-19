using System.Security.Claims;
using Application.Common.Interfaces;
using Application.Data;
using Application.Services.IdentityAuthentication;
using Application.Services.IdentityAuthentication.IdentityModels;
using Infrastructure.Authentication;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Application.Services.Authentication;

public class AuthenticationService: IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IIdentityAuthentication _identityAuthentication;
    private readonly IUnitOfWork _unitOfWork;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IIdentityAuthentication identityAuthentication, IUnitOfWork unitOfWork)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _identityAuthentication = identityAuthentication;
        _unitOfWork = unitOfWork;
    }
    private async Task<IEnumerable<Claim>> _generateClaims(string userId, string userAuthId)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId),
            new Claim(JwtRegisteredClaimNames.Jti, userAuthId)
        };
        return claims;
    }

    private async Task<AuthenticationResult> _handleResponse(IdentityResponse user)
    {
        var userId = await _unitOfWork.AuthenticatedUser.GetUserIdByAuthenticationId(user.Id);
        var claims = await _generateClaims(userId, user.Id);
        var jwtResponse = _jwtTokenGenerator.GenerateToken(claims);
        return new AuthenticationResult(userId, jwtResponse.Token, jwtResponse.ExpireOn, true, new List<string>());
    }
    public async Task<AuthenticationResult> Register(string email, string password)
    {
        var user = await _identityAuthentication.Register(new IdentityRequest(email, password));
        if (user.Succeeded)
            return new AuthenticationResult(user.Id, "", null, true, new List<string>());
        return new AuthenticationResult("", "", null, false, user.Errors);
    }
    public async Task<AuthenticationResult> Login(string email, string password)
    {
        var user = await _identityAuthentication.Login(new IdentityRequest(email, password));
        if (!user.Succeeded)
            return new AuthenticationResult("", "", null,false, user.Errors);
        return await _handleResponse(user);
    }
}