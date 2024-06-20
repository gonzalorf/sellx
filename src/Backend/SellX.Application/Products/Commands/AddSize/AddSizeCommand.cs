using SellX.Application.Configuration.Commands;
using SellX.Domain.Products;

namespace SellX.Application.Products.Commands.AddSize;

public record AddSizeCommand
(
    ProductId ProductId
    , string Name
    , string Code
    , decimal Price
    , decimal StrikethroughPrice
) : CommandBase<SizeId>;



