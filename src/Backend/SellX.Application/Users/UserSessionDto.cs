namespace SellX.Application.Usuarios;

public record UserSessionDto(string Name, string LastName, string Email, string Login, string Role, string Token);
