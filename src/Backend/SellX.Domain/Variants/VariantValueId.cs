using SellX.Domain.SeedWork;

namespace SellX.Domain.Variants;
public record VariantValueId(Guid Value) : TypedIdValueBase(Value);