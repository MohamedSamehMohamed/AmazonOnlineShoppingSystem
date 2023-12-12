namespace Application.Users;

public record UserRegistrationResponse(string UserId, bool Succeed, List<string> Errors);