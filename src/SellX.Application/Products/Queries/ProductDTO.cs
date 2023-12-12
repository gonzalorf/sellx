namespace SellX.Application.Products.Queries;

public record ProductDTO(
        Guid Id,
        string Name,
        string Description,
        decimal Price,
        string[] Tags
    );