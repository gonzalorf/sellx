using SellX.Application.Configuration.Commands;
using SellX.Domain.Products;

namespace SellX.Application.Products.Commands.AddProduct;
public record CreateProductCommand(
        string Name,
        string Description,
        decimal Price,
        decimal StrikethroughPrice,
        Guid ProviderId,
        string[] Tags,
        CreateProductCommandSize[] Sizes
    ) : CommandBase<ProductId>;

public record CreateProductCommandSize(
    string Name
    , string Code
    , decimal Price
    , decimal StrikethroughPrice
);