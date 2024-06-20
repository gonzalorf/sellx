namespace SellX.Domain.SeedWork;

public record DomainEventBase : IDomainEvent
{
    public DomainEventBase()
    {
        OccurredOn = DateTime.Now;
    }

    public DateTime OccurredOn { get; }

    public TenantId TenantId { get; set; }
}