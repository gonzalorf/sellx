using SellX.Application.Configuration.Commands;
using SellX.Domain.Providers;
using SellX.Domain.Providers.Events;

namespace SellX.Application.Providers.Commands.CreateProvider;
internal class CreateProviderCommandHandler : ICommandHandler<CreateProviderCommand, ProviderId>
{
    private readonly IProviderRepository providerRepository;

    public CreateProviderCommandHandler(IProviderRepository providerRepository)
    {
        this.providerRepository = providerRepository;
    }

    public async Task<ProviderId> Handle(CreateProviderCommand request, CancellationToken cancellationToken)
    {
        var provider = Provider.CreateProvider(
            request.Name
            , request.BankAccountNumber
            , request.BankAccountAlias
            );
        await providerRepository.Add(provider);
        provider.AddDomainEvent(new ProviderCreatedEvent(provider.Id));
        return provider.Id;
    }
}