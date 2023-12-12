using SellX.Domain.SeedWork;

namespace SellX.Domain.Products;
public class Product : AuditableEntity<ProductId>, IAggregateRoot
{
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }

    private readonly List<string> tags = new();

    public IReadOnlyCollection<string> Tags => tags.AsReadOnly();

    private Product() : base() { }

    private Product(ProductId id, string name, string description, decimal price, string[] tags) : base(id)
    {
        Name = name;
        Description = description;
        Price = price;
        this.tags = new(tags);
    }

    public static Product CreateProduct(string name, string description, decimal price, string[] tags)
    {
        var product = new Product(new ProductId(Guid.NewGuid()), name, description, price, tags);
        ProductValidator.ValidateProduct(product);
        return product;
    }

    public void UpdateProperties(string name, string description, decimal price, string[] tags)
    {
        Name = name;
        Description = description;
        Price = price;
        this.tags.Clear();
        this.tags.AddRange(tags);

        ProductValidator.ValidateProduct(this);
    }
}
