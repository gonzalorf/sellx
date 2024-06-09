using Carter;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SellX.Application.Orders.Commands.PlaceOrder;
using SellX.Application.Products.Commands.AddProduct;

namespace SellX.API.Endpoints;

public class OrderEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/order");

        _ = group.MapPost("", PlaceOrder);
    }

    [Authorize]
    private static async Task<IResult> PlaceOrder([FromBody] PlaceOrderCommand command, ISender sender)
    {
        var result = await sender.Send(command);
        return Results.Ok(result.Value);
    }

}
