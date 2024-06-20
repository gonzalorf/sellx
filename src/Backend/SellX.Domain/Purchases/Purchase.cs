using SellX.Domain.Providers;
using SellX.Domain.SeedWork;

namespace SellX.Domain.Purchases;

public class Purchase : AuditableEntity<PurchaseId>, IAggregateRoot
{
    public DateOnly Date { get; private set;}
    public ProviderId ProviderId { get; private set; }

    private Purchase(){}
}
