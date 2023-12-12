using SellX.Domain.SeedWork;

namespace SellX.Domain.Stocks;
public record StockId(Guid Value) : TypedIdValueBase(Value);