using AutoMapper;
using SellX.Application.Configuration.Queries;
using SellX.Domain.Providers;

namespace SellX.Application.Providers.Queries.GetProvider;
internal class GetProvidersQueryHandler : IQueryHandler<GetProvidersQuery, IEnumerable<Provider>>
{
    private readonly IProviderRepository providerRepository;

    public GetProvidersQueryHandler(IProviderRepository providerRepository)
    {
        this.providerRepository = providerRepository;
    }

    public async Task<IEnumerable<Provider>> Handle(GetProvidersQuery request, CancellationToken cancellationToken)
    {
        return await providerRepository.GetAll();
    }
}