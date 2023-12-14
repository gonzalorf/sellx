using SellX.Domain.SeedWork;

namespace SellX.Domain.Orders.Events;
public record OrderPlacedEvent(OrderId OrderId) : DomainEventBase;