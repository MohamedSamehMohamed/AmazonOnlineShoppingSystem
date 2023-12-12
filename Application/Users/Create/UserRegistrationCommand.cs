using MediatR;

namespace Application.Users;

public record UserRegistrationCommand(string Name, string Email, string Password): IRequest<UserRegistrationResponse>;