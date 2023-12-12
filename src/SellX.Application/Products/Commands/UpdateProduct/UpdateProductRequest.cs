namespace SellX.Application.Products.Commands.UpdateProduct;
public record UpdateProductRequest(
        string Name,
        string Description,
        decimal Price,
        decimal PreviousPrice,
        string[] Tags
    );