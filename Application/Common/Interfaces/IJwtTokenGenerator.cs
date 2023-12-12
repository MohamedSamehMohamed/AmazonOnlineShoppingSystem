using Infrastructure.Authentication;

namespace Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    JwtResponse GenerateToken(JwtUserModel userModel);
}