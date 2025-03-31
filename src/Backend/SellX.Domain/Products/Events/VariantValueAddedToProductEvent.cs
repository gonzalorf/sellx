using SellX.Domain.SeedWork;

namespace SellX.Domain.Products.Events;
public record ProductVariantAddedEvent(ProductId ProductId, ProductVariantId ProductVariantId) : DomainEventBase;