using FluentValidation;
using SellX.Domain.Products.Exceptions;

namespace SellX.Domain.Products.Validators;
public class SizeValidator : AbstractValidator<Size>
{
    public SizeValidator()
    {
        RuleFor(p => p.Name).NotEmpty().MaximumLength(24);
        RuleFor(p => p.Price).GreaterThanOrEqualTo(0);
        RuleFor(p => p.PreviousPrice).GreaterThanOrEqualTo(0);
    }

    public static void ValidateSize(Size product)
    {
        var validator = new SizeValidator();
        var validationResult = validator.Validate(product);

        if (!validationResult.IsValid)
        {
            throw new SizeInvalidStateException(validationResult.ToString());
        }
    }
}