using SellX.Domain.Providers;
using SellX.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace SellX.Infrastructure.Domain.Providers;
public class ProviderRepository : IProviderRepository
{
    private readonly IApplicationDbContext context;

    public ProviderRepository(IApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task Add(Provider provider)
    {
        _ = await context.Providers.AddAsync(provider);
    }

    public async Task<IEnumerable<Provider>> GetAll()
    {
        return await context.Providers.ToListAsync();
    }

    public void Remove(Provider provider)
    {
        _ = context.Providers.Remove(provider);
    }

    public void Update(Provider provider)
    {
        _ = context.Providers.Update(provider);
    }

    public async Task<Provider?> GetById(ProviderId id)
    {
        return await context.Providers.SingleAsync(p => p.Id == id);
    }
}