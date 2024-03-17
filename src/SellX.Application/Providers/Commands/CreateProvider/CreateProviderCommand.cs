
using SellX.Application.Configuration.Commands;
using SellX.Domain.Providers;

namespace SellX.Application.Providers.Commands.CreateProvider;

public record CreateProviderCommand(
    string Name,
    string BankAccountNumber,
    string BankAccountAlias
) : CommandBase<ProviderId>;