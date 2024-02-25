using SellX.Application.Configuration.Commands;
using SellX.Domain.Products;

namespace SellX.Application.Products.Commands.UpdateProduct;

public record UpdateProductCommand(
        ProductId ProductId,
        string Name,
        string Description,
        decimal Price,
        decimal StrikethroughPrice,
        string[] Tags
    ) : CommandBase;