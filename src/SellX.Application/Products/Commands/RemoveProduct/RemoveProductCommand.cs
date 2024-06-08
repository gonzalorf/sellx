using SellX.Application.Configuration.Commands;
using SellX.Domain.Products;

namespace SellX.Application.Products.Commands.DeleteProduct;

public record RemoveProductCommand(
    ProductId ProductId
) : CommandBase;