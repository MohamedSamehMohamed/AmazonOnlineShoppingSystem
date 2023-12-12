using Application.Data;
using Application.Services.Authentication;
using Domain.Users;
using MediatR;

namespace Application.Users;

public class UserRegistrationHandler: IRequestHandler<UserRegistrationCommand, UserRegistrationResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthenticationService _authenticationService;
    public UserRegistrationHandler(IUnitOfWork unitOfWork, IAuthenticationService authenticationService)
    {
        _unitOfWork = unitOfWork;
        _authenticationService = authenticationService;
    }
    public async Task<UserRegistrationResponse> Handle(UserRegistrationCommand request, CancellationToken cancellationToken)
    {
        var authenticateResponse = 
            await _authenticationService.Register(request.Email, request.Password);
        if (!authenticateResponse.Succeeded)
            return new UserRegistrationResponse("", false, authenticateResponse.Errors);
        var user = new User
        {
            AuthenticationId = authenticateResponse.Id,
            Name = request.Name
        };
        if (!await _unitOfWork.AuthenticatedUser.AddAsync(user))
        {
            return new UserRegistrationResponse("", false, new List<string>(){"fail to add the user"});
        }
        await _unitOfWork.SaveChangeAsync();
        return new UserRegistrationResponse(user.UserId, true, new List<string>());
    }
}