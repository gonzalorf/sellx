using SellX.Domain.SeedWork;
using SellX.Domain.Variants;

namespace SellX.Domain.Products.Events;
public record VariantValueAddedToProductEvent(ProductId ProductId, VariantValueId VariantValueId) : DomainEventBase;