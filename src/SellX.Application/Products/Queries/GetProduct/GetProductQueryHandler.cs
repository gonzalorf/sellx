using SellX.Application.Configuration.Queries;
using SellX.Domain.Products.Exceptions;
using SellX.Domain.Products;
using SellX.Application.Products.Dtos;
using AutoMapper;

namespace SellX.Application.Products.Queries.GetProduct;
internal class GetProductQueryHandler : IQueryHandler<GetProductQuery, ProductDto>
{
    private readonly IProductRepository productRepository;
    private readonly IMapper mapper;

    public GetProductQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        this.productRepository = productRepository;
        this.mapper = mapper;
    }

    public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetById(request.ProductId) ?? throw new ProductNotFoundException(request.ProductId);

        return mapper.Map<ProductDto>(product);
    }
}