using MediatR;

namespace SellX.Domain.SeedWork;
public interface IDomainEvent : INotification
{
    DateTime OccurredOn { get; }
    TenantId TenantId { get; set; }
}