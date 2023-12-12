using SellX.Domain.SeedWork;

namespace SellX.Domain.Products.Events;
public record SizeAddedEvent(ProductId ProductId, SizeId SizeId) : DomainEventBase;