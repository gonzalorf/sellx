namespace SellX.Domain.Users;

public record UserRole()
{
    public string? Name { get; private set; }
    public static UserRole Administrator => new() { Name = "Administrador" };
    public static UserRole TerminalDeMarcado => new() { Name = "TerminalDeMarcado" };
    public static UserRole AplicacionMobile => new() { Name = "AplicacionMobile" };
    public static UserRole CreateFromName(string? name)
    {
        return new UserRole() { Name = name }; // TODO: validate name
    }
}