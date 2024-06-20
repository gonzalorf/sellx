using SellX.Application.Configuration.Commands;
using SellX.Domain.Providers;

namespace SellX.Application.Providers.Commands.UpdateProvider;

public record UpdateProviderCommand(
        ProviderId ProviderId,
        string Name,
        string BankAccountNumber,
        string BankAccountAlias
    ) : CommandBase;