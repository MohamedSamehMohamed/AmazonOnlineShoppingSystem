namespace Infrastructure.Authentication;

public record JwtResponse(bool Succeeded, string Token, DateTime ExpireOn, List<string> Errors);