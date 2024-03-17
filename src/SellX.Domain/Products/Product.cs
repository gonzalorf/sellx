﻿using SellX.Domain.Products.Events;
using SellX.Domain.Products.Validators;
using SellX.Domain.Providers;
using SellX.Domain.SeedWork;

namespace SellX.Domain.Products;
public class Product : AuditableEntity<ProductId>, IAggregateRoot
{
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public decimal StrikethroughPrice { get; private set; }
    public ProviderId ProviderId { get; private set; }
    public Provider Provider { get; private set; }

    private readonly List<string> tags = new();
    public IReadOnlyCollection<string> Tags => tags.AsReadOnly();

    private readonly List<Size> sizes = new();
    public IReadOnlyCollection<Size> Sizes => sizes.AsReadOnly();

    private Product() : base() { }

    private Product(ProductId id, string name, string description, decimal price, decimal strikethroughPrice, ProviderId providerId, string[] tags) : base(id)
    {
        Name = name;
        Description = description;
        Price = price;
        StrikethroughPrice = strikethroughPrice;
        ProviderId = providerId;
        this.tags = new(tags);
    }

    public static Product CreateProduct(string name, string description, decimal price, decimal strikethroughPrice, ProviderId providerId, string[] tags, Size[] sizes)
    {
        var product = new Product(new ProductId(Guid.NewGuid()), name, description, price, strikethroughPrice, providerId, tags);

        foreach(var size in sizes) { product.AddSize(size); }

        ProductValidator.ValidateProduct(product);
        product.AddDomainEvent(new ProductCreatedEvent(product.Id));

        return product;
    }

    public void UpdateProperties(string name, string description, decimal price, decimal strikethroughPrice, string[] tags)
    {
        Name = name;
        Description = description;
        Price = price;
        StrikethroughPrice = strikethroughPrice;
        this.tags.Clear();
        this.tags.AddRange(tags);

        ProductValidator.ValidateProduct(this);
    }

    public Size AddSize(
        string name
        , string code
        , decimal price
        , decimal strikethroughPrice)
    {
        var size = Size.CreateSize(name, code, price, strikethroughPrice);
        sizes.Add(size);
        AddDomainEvent(new SizeAddedEvent(Id, size.Id));

        return size;
    }

    public Size AddSize(
        Size size)
    {
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
