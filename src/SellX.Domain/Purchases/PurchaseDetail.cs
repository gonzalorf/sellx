using SellX.Domain.Products;
using SellX.Domain.SeedWork;

namespace SellX.Domain.Purchases;

public class PurchaseDetail : Entity<PurchaseDetailId>
{
    public ProductId ProductId { get; private set; }
    public SizeId SizeId { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }

    private PurchaseDetail(){}
}
