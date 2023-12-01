namespace Application.Services.Authentication;

public record AuthenticationResult(string Id, string Token, DateTime? ExpireOn, bool Succeeded, List<string> Errors);