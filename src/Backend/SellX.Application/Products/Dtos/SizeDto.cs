namespace SellX.Application.Products.Dtos;

public record SizeDto(
    Guid Id,
    string Name,
    string Code,
    decimal Price,
    decimal StrikethroughPrice
){
    public SizeDto() : this(Guid.Empty, string.Empty, string.Empty, 0, 0)
    {

    }
};