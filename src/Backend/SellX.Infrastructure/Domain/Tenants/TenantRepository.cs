using Microsoft.EntityFrameworkCore;
using SellX.Domain.SeedWork;
using SellX.Domain.Tenants;
using SellX.Infrastructure.Database;

namespace SellX.Infrastructure.Domain.Tenants;
public class TenantRepository : ITenantRepository
{
    private readonly IApplicationDbContext context;

    public TenantRepository(IApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<Tenant?> GetById(TenantId id)
    {
        return await context.Tenants.SingleOrDefaultAsync(t => t.Id == id);
    }
}
