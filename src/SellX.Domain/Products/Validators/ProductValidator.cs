using FluentValidation;
using SellX.Domain.Products.Exceptions;

namespace SellX.Domain.Products.Validators;
public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.Name).NotEmpty().MaximumLength(256);
        RuleFor(p => p.Description).NotEmpty();
        RuleFor(p => p.Price).GreaterThan(0);
        RuleFor(p => p.Tags).NotNull();
    }

    public static void ValidateProduct(Product product)
    {
        var validator = new ProductValidator();
        var validationResult = validator.Validate(product);

        if (!validationResult.IsValid)
        {
            throw new ProductInvalidStateException(validationResult.ToString());
        }
    }
}