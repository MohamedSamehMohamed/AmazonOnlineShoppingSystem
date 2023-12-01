namespace Application.Services.IdentityAuthentication.IdentityModels;

public record IdentityResponse(string Id, bool Succeeded, List<string> Errors);