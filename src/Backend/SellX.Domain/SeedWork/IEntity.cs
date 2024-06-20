namespace SellX.Domain.SeedWork;
public interface IEntity
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
    IReadOnlyCollection<IDomainEvent> IntegrationEvents { get; }
    void ClearDomainEvents();
    void ClearIntegrationEvents();

    TenantId TenantId { get; set; }
    bool Deleted { get; set; }
}
