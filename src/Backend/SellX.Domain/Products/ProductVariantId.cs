using SellX.Domain.SeedWork;

namespace SellX.Domain.Products;
public record ProductVariantId(Guid Value) : TypedIdValueBase(Value);