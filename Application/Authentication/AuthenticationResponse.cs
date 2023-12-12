namespace Application.Authentication;

public record AuthenticationResponse(string Id, string JwtToken, DateTime? ExpireOn, bool Succeeded, List<string> Errors);