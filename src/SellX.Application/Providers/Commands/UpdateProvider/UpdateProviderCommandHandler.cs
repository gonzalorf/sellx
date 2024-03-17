using SellX.Application.Configuration.Commands;
using SellX.Domain.Providers;
using SellX.Domain.Providers.Exceptions;

namespace SellX.Application.Providers.Commands.UpdateProvider;
internal class UpdateProviderCommandHandler : ICommandHandler<UpdateProviderCommand>
{
    private readonly IProviderRepository providerRepository;

    public UpdateProviderCommandHandler(IProviderRepository providerRepository)
    {
        this.providerRepository = providerRepository;
    }

    public async Task Handle(UpdateProviderCommand request, CancellationToken cancellationToken)
    {
        var provider = await providerRepository.GetById(request.ProviderId) ?? throw new ProviderNotFoundException(request.ProviderId);

        provider.UpdateProperties(request.Name, request.BankAccountNumber, request.BankAccountAlias);

        providerRepository.Update(provider);
    }
}