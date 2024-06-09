namespace SellX.Application.Products.Commands.AddSize;
public record AddSizeRequest
(
    string Name
    , string Code
    , decimal Price
    , decimal StrikethroughPrice
);
