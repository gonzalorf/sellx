using SellX.Application.Configuration.Queries;
using SellX.Domain.Providers;

namespace SellX.Application.Providers.Queries.GetProvider;

public record GetProvidersQuery() : IQuery<IEnumerable<Provider>>;
