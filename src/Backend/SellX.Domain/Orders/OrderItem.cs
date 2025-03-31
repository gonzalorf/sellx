using SellX.Domain.SeedWork;
using SellX.Domain.Products;

namespace SellX.Domain.Orders;
public class OrderItem : Entity<OrderItemId>
{
    public Product Product { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }

    private OrderItem() : base() { }

    private OrderItem(OrderItemId id, Product product, int quantity, decimal price) : base(id)
    {
        Product = product;
        Quantity = quantity;
        Price = price;
    }

    public static OrderItem CreateOrderItem(Product product, int quantity, decimal price)
    {
        return new OrderItem(new OrderItemId(Guid.NewGuid()), product, quantity, price);
    }
}