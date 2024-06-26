﻿using SellX.Application.Configuration.Commands;
using SellX.Domain.Products.Events;
using SellX.Domain.Products;
using SellX.Domain.Providers;

namespace SellX.Application.Products.Commands.AddProduct;
internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, ProductId>
{
    private readonly IProductRepository productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    public async Task<ProductId> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var sizes = request.Sizes
            .Select(s => Size.CreateSize(s.Name, s.Code, s.Price, s.StrikethroughPrice))
            .ToArray();
            
        var product = Product.CreateProduct(
            request.Name
            , request.Brand
            , request.Description
            , request.Price
            , request.StrikethroughPrice
            , request.Tags
            , sizes
            );

        await productRepository.Add(product);
        product.AddDomainEvent(new ProductCreatedEvent(product.Id));
        return product.Id;
    }
}