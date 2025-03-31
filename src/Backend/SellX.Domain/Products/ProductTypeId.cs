using SellX.Domain.SeedWork;

namespace SellX.Domain.Products;
public record ProductTypeId(Guid Value) : TypedIdValueBase(Value);