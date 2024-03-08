using FluentValidation;
using SellX.Domain.Providers.Exceptions;

namespace SellX.Domain.Providers.Validators;
public class ProviderValidator : AbstractValidator<Provider>
{
    public ProviderValidator()
    {
        RuleFor(p => p.Name).NotEmpty().MaximumLength(256);
        RuleFor(p => p.BankAccountNumber).MaximumLength(256);
        RuleFor(p => p.BankAccountAlias).MaximumLength(256);
    }

    public static void ValidateProvider(Provider Provider)
    {
        var validator = new ProviderValidator();
        var validationResult = validator.Validate(Provider);

        if (!validationResult.IsValid)
        {
            throw new ProviderInvalidStateException(validationResult.ToString());
        }
    }
}