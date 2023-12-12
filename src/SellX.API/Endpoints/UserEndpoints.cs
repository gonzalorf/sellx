using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SellX.Application.Usuarios.Commands.Login;

namespace SellX.API.Endpoints;
public class UserEndpoints : ICarterModule
{

    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/usuario");

        _ = group.MapPost("login", Login);
        //group.MapPost("logout", Logout);
    }

    private static async Task<IResult> Login([FromBody] LoginCommand command, ISender sender)
    {
        var userSession = await sender.Send(command);
        return Results.Ok(userSession);
    }
}
