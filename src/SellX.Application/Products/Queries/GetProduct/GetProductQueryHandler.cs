using NanoBlogEngine.Application.Products.Queries.GetProduct;
using SellX.Application.Configuration.Queries;
using SellX.Domain.Products.Exceptions;
using SellX.Domain.Products;

namespace SellX.Application.Products.Queries.GetProduct;
internal class GetProductQueryHandler : IQueryHandler<GetProductQuery, ProductDto>
{
    private readonly IProductRepository productRepository;

    public GetProductQueryHandler(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetById(request.ProductId) ?? throw new ProductNotFoundException(request.ProductId);

        return new ProductDto(
            product.Id.Value,
            product.Name,
            product.Description,
            product.Price,
            product.StrikethroughPrice,
            product.Tags.ToArray()
        );
    }
}