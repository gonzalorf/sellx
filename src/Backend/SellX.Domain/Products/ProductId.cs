using SellX.Domain.SeedWork;

namespace SellX.Domain.Products;
public record ProductId(Guid Value) : TypedIdValueBase(Value);