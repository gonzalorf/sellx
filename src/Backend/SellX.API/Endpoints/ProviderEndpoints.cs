using Carter;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SellX.Application.Providers.Commands.CreateProvider;
using SellX.Application.Providers.Commands.RemoveProvider;
using SellX.Application.Providers.Commands.UpdateProvider;
using SellX.Application.Providers.Queries.GetProvider;
using SellX.Domain.Providers;

namespace SellX.API.Endpoints;


public class ProviderEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/Provider");

        _ = group.MapPost("", CreateProvider);
        _ = group.MapPut("", UpdateProvider);
        _ = group.MapDelete("", RemoveProvider);
        _ = group.MapGet("", GetProviders);
    }

    [Authorize]
    private static async Task<IResult> CreateProvider([FromBody] CreateProviderCommand command, ISender sender)
    {
        var result = await sender.Send(command);
        return Results.Ok(result.Value);
    }

    [Authorize]
    private static async Task<IResult> UpdateProvider(Guid id, [FromBody] UpdateProviderRequest request, ISender sender)
    {
        var command = new UpdateProviderCommand(
                new ProviderId(id)
                , request.Name
                , request.BankAccountNumber
                , request.BankAccountAlias
                );

        await sender.Send(command);
        return Results.Ok();
    }

    [Authorize]
    private static async Task<IResult> RemoveProvider([FromQuery] Guid id, ISender sender)
    {
        await sender.Send(new RemoveProviderCommand(new ProviderId(id)));
        return Results.Ok();
    }

    [Authorize]
    private static async Task<IResult> GetProviders(ISender sender)
    {
        return Results.Ok(await sender.Send(new GetProvidersQuery()));
    }
}
