using SellX.Application.Configuration.Commands;
using SellX.Domain.Products;

namespace SellX.Application.Products.Commands.RemoveSize;

public record RemoveSizeCommand(
    ProductId ProductId
    , SizeId SizeId
) : CommandBase;
