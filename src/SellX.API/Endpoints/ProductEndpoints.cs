using Carter;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NanoBlogEngine.Application.Products.Queries.GetProduct;
using SellX.Application.Products.Commands.AddProduct;
using SellX.Application.Products.Commands.DeleteProduct;
using SellX.Application.Products.Commands.UpdateProduct;
using SellX.Domain.Products;

namespace SellX.API.Endpoints;


public class ProductEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/product");

        _ = group.MapPost("", CreateProduct);
        _ = group.MapPut("", UpdateProduct);
        _ = group.MapDelete("", RemoveProduct);
        _ = group.MapGet("", GetProduct);
    }

    [Authorize]
    private static async Task<IResult> CreateProduct([FromBody] CreateProductCommand command, ISender sender)
    {
        var result = await sender.Send(command);
        return Results.Ok(result.Value);
    }

    [Authorize]
    private static async Task<IResult> UpdateProduct(Guid id, [FromBody] UpdateProductRequest request, ISender sender)
    {
        var command = new UpdateProductCommand(
                new ProductId(id)
                , request.Name
                , request.Description
                , request.Price
                , request.PreviousPrice
                , request.Tags
                );

        await sender.Send(command);
        return Results.Ok();
    }

    [Authorize]
    private static async Task<IResult> RemoveProduct([FromQuery] Guid id, ISender sender)
    {
        await sender.Send(new RemoveProductCommand(new ProductId(id)));
        return Results.Ok();
    }

    [Authorize]
    private static async Task<IResult> GetProduct(Guid id, ISender sender)
    {
        return Results.Ok(await sender.Send(new GetProductQuery(new ProductId(id))));
    }
}
