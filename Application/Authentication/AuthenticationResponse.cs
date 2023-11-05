namespace Application.Authentication;

public record AuthenticationResponse(string Id, string Token, DateTime? ExpireOn, bool Succeeded, List<string> Errors);