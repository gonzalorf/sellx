using SellX.Application.Configuration.Commands;
using SellX.Domain.Products;

namespace SellX.Application.Products.Commands.AddProduct;
public record CreateProductCommand(
        string Name,
        string Description,
        decimal Price,
        string[] Tags
    ) : CommandBase<ProductId>;