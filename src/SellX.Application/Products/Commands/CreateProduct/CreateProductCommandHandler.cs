using SellX.Application.Configuration.Commands;
using SellX.Domain.Products.Events;
using SellX.Domain.Products;

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
        var product = Product.CreateProduct(request.Name, request.Description, request.Price, request.Tags);
        await productRepository.Add(product);
        product.AddDomainEvent(new ProductCreatedEvent(product.Id));
        return product.Id;
    }
}