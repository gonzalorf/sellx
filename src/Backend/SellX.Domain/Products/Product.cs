using SellX.Domain.Products.Events;
using SellX.Domain.Products.Validators;
using SellX.Domain.SeedWork;
using SellX.Domain.Variants;

namespace SellX.Domain.Products;
public class Product : AuditableEntity<ProductId>, IAggregateRoot
{
    public string Name { get; private set; } = string.Empty;
    public string Brand { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public ProductType ProductType { get; private set; } = null!;
    public decimal Price { get; private set; }
    public decimal StrikethroughPrice { get; private set; }
    
    private readonly List<string> tags = new();
    public IReadOnlyCollection<string> Tags => tags.AsReadOnly();

    private readonly List<ProductVariant> productVariants = new();
    public IReadOnlyCollection<ProductVariant> ProductVariants => productVariants.AsReadOnly();

    private Product() : base() { }

    private Product(ProductId id, string name, string brand, string description, ProductType productType, decimal price, decimal strikethroughPrice, string[] tags) : base(id)
    {
        Name = name;
        Brand = brand;
        Description = description;
        Price = price;
        StrikethroughPrice = strikethroughPrice;
        this.tags = new(tags);
        ProductType = productType;
    }

    public static Product CreateProduct(string name, string brand, string description, ProductType productType, decimal price, decimal strikethroughPrice, string[] tags)
    {
        var product = new Product(new ProductId(Guid.NewGuid()), name, brand, description, productType, price, strikethroughPrice, tags);

        ProductValidator.ValidateProduct(product);
        product.AddDomainEvent(new ProductCreatedEvent(product.Id));

        return product;
    }

    public void UpdateProperties(string name, string brand, string description, ProductType productType, decimal price, decimal strikethroughPrice, string[] tags)
    {
        Name = name;
        Brand = brand;
        Description = description;
        ProductType = productType;
        Price = price;
        StrikethroughPrice = strikethroughPrice;
        this.tags.Clear();
        this.tags.AddRange(tags);

        ProductValidator.ValidateProduct(this);
    }

    public ProductVariant AddProductVariant(ProductVariant productVariant)
    {
        productVariants.Add(productVariant);
        AddDomainEvent(new ProductVariantAddedEvent(Id, productVariant.Id));

        return productVariant;
    }

    public void RemoveProductVariant(ProductVariant productVariant)
    {
        productVariants.Remove(productVariant);
    }
}
