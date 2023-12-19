namespace NanoBlogEngine.Application.Products.Queries.GetProduct;

public record ProductDto(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    decimal PreviousPrice,
    string[] Tags
);