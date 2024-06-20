using SellX.Domain.SeedWork;

namespace SellX.Domain.Products.Events;
public record ProductCreatedEvent(ProductId ProductId) : DomainEventBase;