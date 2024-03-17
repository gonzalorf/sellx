namespace SellX.Application.Products.Dtos;

public record ProductDto(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    decimal StrikethroughPrice,
    string[] Tags,
    SizeDto[] Sizes,
    Guid ProviderId,
    string ProviderName
)
{
    public ProductDto() : this(Guid.Empty, string.Empty, string.Empty, 0, 0, Array.Empty<string>(), Array.Empty<SizeDto>(), Guid.Empty, string.Empty)
    {

    }
};