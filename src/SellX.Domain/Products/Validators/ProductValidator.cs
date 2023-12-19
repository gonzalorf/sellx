using FluentValidation;
using SellX.Domain.Products.Exceptions;

namespace SellX.Domain.Products.Validators;
public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.Name).NotEmpty().MaximumLength(256);
        RuleFor(p => p.Description).NotEmpty().MaximumLength(256);
        RuleFor(p => p.Price).GreaterThanOrEqualTo(0);
        RuleFor(p => p.Tags).NotNull();
        RuleFor(p => p.Sizes.Count).GreaterThan(0);
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