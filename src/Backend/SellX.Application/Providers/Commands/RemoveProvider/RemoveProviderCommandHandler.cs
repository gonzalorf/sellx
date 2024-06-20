using SellX.Application.Configuration.Commands;
using SellX.Domain.Products.Exceptions;
using SellX.Domain.Products;
using SellX.Application.Providers.Commands.RemoveProvider;
using SellX.Domain.Providers;
using SellX.Domain.Providers.Exceptions;

namespace SellX.Application.Products.Commands.DeleteProduct;
internal class RemoveProviderCommandHandler : ICommandHandler<RemoveProviderCommand>
{
    private readonly IProviderRepository providerRepository;

    public RemoveProviderCommandHandler(IProviderRepository ProviderRepository)
    {
        this.providerRepository = ProviderRepository;
    }

    public async Task Handle(RemoveProviderCommand request, CancellationToken cancellationToken)
    {
        var Provider = await providerRepository.GetById(request.ProviderId) ?? throw new ProviderNotFoundException(request.ProviderId);

        providerRepository.Remove(Provider);
    }
}