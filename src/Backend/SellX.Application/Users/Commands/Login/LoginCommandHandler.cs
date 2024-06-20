using SellX.Application.Configuration.Commands;
using SellX.Application.Configuration.Services;
using SellX.Application.Services;
using SellX.Domain.Users;
using SellX.Domain.Users.Events;
using SellX.Domain.Users.Exceptions;

namespace SellX.Application.Usuarios.Commands.Login;
internal sealed class LoginCommandHandler
    : ICommandHandler<LoginCommand, UserSessionDto>
{
    private readonly IJwtProvider jwtProvider;
    private readonly IUserRepository userRepository;
    private readonly IPasswordHashService passwordHashService;

    public LoginCommandHandler(IJwtProvider jwtProvider, IUserRepository userRepository, IPasswordHashService passwordHashService)
    {
        this.jwtProvider = jwtProvider;
        this.userRepository = userRepository;
        this.passwordHashService = passwordHashService;
    }

    public async Task<UserSessionDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByLogin(request.Login) ?? throw new UserNotFoundException(request.Login);

        // TODO: verificar la pass
        var jwt = jwtProvider.GetJwt(user);

        var userSession = new UserSessionDto(user.Name, user.LastName, user.Email, user.Login, user.Role.Name, jwt);

        user.AddDomainEvent(new LoginPerformedEvent(user.Id));

        return userSession;
    }
}
