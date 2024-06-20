using SellX.Application.Configuration.Commands;

namespace SellX.Application.Usuarios.Commands.Login;
public record LoginCommand(string Login, string Password) : CommandBase<UserSessionDto>;
