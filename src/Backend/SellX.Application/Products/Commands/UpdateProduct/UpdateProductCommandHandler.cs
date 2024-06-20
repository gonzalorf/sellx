using SellX.Application.Configuration.Commands;
using SellX.Domain.Products.Exceptions;
using SellX.Domain.Products;

namespace SellX.Application.Products.Commands.UpdateProduct;
internal class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand>
{
    private readonly IProductRepository productRepository;

    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetById(request.ProductId) ?? throw new ProductNotFoundException(request.ProductId);

        product.UpdateProperties(request.Name,
                                 request.Brand,
                                 request.Description,
                                 request.Price,
                                 request.StrikethroughPrice,
                                 request.Tags);

        productRepository.Update(product);
    }
}