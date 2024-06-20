using SellX.Application.Configuration.Commands;
using SellX.Domain.Providers;

namespace SellX.Application.Providers.Commands.RemoveProvider;

public record RemoveProviderCommand
(
    ProviderId ProviderId
) : CommandBase;