namespace SellX.Application.Providers.Commands.UpdateProvider;
public record UpdateProviderRequest(
        string Name,
        string BankAccountNumber,
        string BankAccountAlias
    );