using SellX.Domain.SeedWork;

namespace SellX.Domain.Variants;
public record VariantId(Guid Value) : TypedIdValueBase(Value);