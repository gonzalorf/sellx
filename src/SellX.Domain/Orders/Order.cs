using SellX.Domain.Orders.Events;
using SellX.Domain.Products;
using SellX.Domain.SeedWork;

namespace SellX.Domain.Orders;

public class Order : AuditableEntity<OrderId>, IAggregateRoot
{
    public DateOnly Date { get; private set;}
    public ProductId ProductId { get; private set; }
    public SizeId SizeId { get; private set; }
    public int Count { get; private set; }
    public string Customer { get; private set; }
    public string CustomerEmail { get; private set; }
    public decimal Price { get; private set; }

    private Order(){}

    private Order(OrderId id, DateOnly date, ProductId productId, SizeId sizeId, int count, string customer, string customerEmail, decimal price) : base(id)
    {
        Date = date;
        ProductId = productId;
        SizeId = sizeId;
        Count = count;
        Customer = customer;
        CustomerEmail = customerEmail;
        Price = price;
    }

    public static Order CreateOrder(DateOnly date, ProductId productId, SizeId sizeId, int count, string customer, string customerEmail, decimal price)
    {
        var order = new Order(new OrderId(Guid.NewGuid()), date, productId, sizeId, count, customer, customerEmail, price);
        OrderValidator.ValidateOrder(order);
        order.AddDomainEvent(new OrderPlacedEvent(order.Id));

        return order;
    }
}
