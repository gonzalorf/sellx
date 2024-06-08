using SellX.Application.Configuration.Commands;
using SellX.Domain.Products;

namespace SellX.Application.Products.Commands.RemoveSize;

public record RemoveSizeCommand(
    Guid ProductId
    , Guid SizeId
) : CommandBase;
