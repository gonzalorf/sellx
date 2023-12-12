using SellX.Domain.SeedWork;

namespace SellX.Domain.Tenants;
public interface ITenantRepository
{
    Task<Tenant?> GetById(TenantId id);
}
