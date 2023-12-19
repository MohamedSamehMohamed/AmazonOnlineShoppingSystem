using System.Security.Claims;
using Infrastructure.Authentication;

namespace Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    JwtResponse GenerateToken(JwtUserModel userModel);
    JwtResponse GenerateToken(IEnumerable<Claim> claims);
}