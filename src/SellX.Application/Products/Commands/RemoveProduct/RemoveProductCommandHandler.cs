using SellX.Application.Configuration.Commands;
using SellX.Domain.Products.Exceptions;
using SellX.Domain.Products;

namespace SellX.Application.Products.Commands.DeleteProduct;
internal class RemoveProductCommandHandler : ICommandHandler<RemoveProductCommand>
{
    private readonly IProductRepository productRepository;

    public RemoveProductCommandHandler(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    public async Task Handle(RemoveProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetById(request.ProductId);

        if (product == null)
        {
            throw new ProductNotFoundException(request.ProductId);
        }

        productRepository.Remove(product);
    }
}