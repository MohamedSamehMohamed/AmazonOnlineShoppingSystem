using Application.Authentication;
using Application.Services.IdentityAuthentication.IdentityModels;

namespace Application.Services.IdentityAuthentication;

public interface IIdentityAuthentication
{
    public Task<IdentityResponse> Register(IdentityRequest registerRequest);
    public Task<IdentityResponse> Login(IdentityRequest loginRequest);
}