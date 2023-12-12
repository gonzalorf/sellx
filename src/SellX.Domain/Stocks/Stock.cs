using SellX.Domain.Products;
using SellX.Domain.SeedWork;
using SellX.Domain.Stocks.Validators;

namespace SellX.Domain.Stocks;
public class Stock : AuditableEntity<StockId>, IAggregateRoot
{
    public ProductId ProductId { get; private set; }
    public SizeId SizeId { get; private set; }
    public int Count { get; set; }
    private Stock() : base() { }

    private Stock(StockId id, ProductId productId, SizeId sizeId, int count) : base(id)
    {
        ProductId = productId;
        SizeId = sizeId;
        Count = count;
    }

    public static Stock CreateSize(ProductId productId, SizeId sizeId, int count)
    {
        var stock = new Stock(new StockId(Guid.NewGuid()), productId, sizeId, count);
        StockValidator.ValidateStock(stock);
        return stock;
    }
}
