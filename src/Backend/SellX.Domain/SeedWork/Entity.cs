namespace SellX.Domain.SeedWork;

/// <summary>
/// Base class for entities.
/// </summary>
public abstract class Entity<TIdType> : IEntity where TIdType : TypedIdValueBase
{
    public TIdType Id { get; protected set; }
    public TenantId TenantId { get; set; } = new(Guid.Empty);
    public bool Deleted { get; set; }
    public long Order { get; private set; }

    protected Entity(TIdType id)
    {
        Id = id;
    }
    protected Entity() { }

    readonly List<IDomainEvent> domainEvents = new();
    readonly List<IDomainEvent> integrationEvents = new();

    public IReadOnlyCollection<IDomainEvent>? DomainEvents => domainEvents?.AsReadOnly();
    public IReadOnlyCollection<IDomainEvent>? IntegrationEvents => integrationEvents?.AsReadOnly();

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        domainEvents.Clear();
    }

    public void AddIntegrationEvent(IDomainEvent integrationEvent)
    {
        integrationEvents.Add(integrationEvent);
    }

    public void ClearIntegrationEvents()
    {
        integrationEvents.Clear();
    }
}