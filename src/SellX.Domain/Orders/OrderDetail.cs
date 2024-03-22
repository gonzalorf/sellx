using SellX.Domain.Products;
using SellX.Domain.SeedWork;

namespace SellX.Domain.Orders;

public class OrderDetail : Entity<OrderDetailId>
{
    public ProductId ProductId { get; private set; }
    public SizeId SizeId { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }

    private OrderDetail(){}

    private OrderDetail(OrderDetailId id, ProductId productId, SizeId sizeId, int count, decimal price) : base(id)
    {
        ProductId = productId;
        SizeId = sizeId;
        Quantity = count;
        Price = price;
    }

    public static OrderDetail CreateOrderDetail(ProductId productId, SizeId sizeId, int count, decimal price)
    {
        var orderDetail = new OrderDetail(new OrderDetailId(Guid.NewGuid()), productId, sizeId, count, price);
        OrderDetailValidator.ValidateOrderDetail(orderDetail);

        return orderDetail;
    }

}