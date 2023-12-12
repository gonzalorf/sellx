using SellX.Domain.Products.Events;
using SellX.Domain.SeedWork;
using System.Text.RegularExpressions;

namespace SellX.Domain.Products;
public class Product : AuditableEntity<ProductId>, IAggregateRoot
{
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public decimal PreviousPrice { get; private set; }

    private readonly List<string> tags = new();
    public IReadOnlyCollection<string> Tags => tags.AsReadOnly();

    private readonly List<Size> sizes = new();
    public IReadOnlyCollection<Size> Sizes => sizes.AsReadOnly();

    private Product() : base() { }

    private Product(ProductId id, string name, string description, decimal price, decimal previousPrice, string[] tags) : base(id)
    {
        Name = name;
        Description = description;
        Price = price;
        PreviousPrice = previousPrice;
        this.tags = new(tags);
    }

    public static Product CreateProduct(string name, string description, decimal price, decimal previousPrice, string[] tags)
    {
        var product = new Product(new ProductId(Guid.NewGuid()), name, description, price, previousPrice, tags);
        ProductValidator.ValidateProduct(product);
        product.AddDomainEvent(new ProductCreatedEvent(product.Id));

        return product;
    }

    public void UpdateProperties(string name, string description, decimal price, decimal previousPrice, string[] tags)
    {
        Name = name;
        Description = description;
        Price = price;
        PreviousPrice = previousPrice;
        this.tags.Clear();
        this.tags.AddRange(tags);

        ProductValidator.ValidateProduct(this);
    }

    public Size AddSize(
        string name
        , string code
        , decimal price
        , decimal previousPrice)
    {
        var size = Size.CreateSize(name, code, price, previousPrice);
        sizes.Add(size);
        AddDomainEvent(new SizeAddedEvent(Id, size.Id));

        return size;
    }

    public void RemoveSize(
        Size size)
    {
        sizes.Remove(size);
    }
}
