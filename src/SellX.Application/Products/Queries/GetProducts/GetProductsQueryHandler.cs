using AutoMapper;
using SellX.Application.Configuration.Queries;
using SellX.Application.Products.Dtos;
using SellX.Domain.Products;
using SellX.Domain.Providers;

namespace SellX.Application.Products.Queries.GetProduct;
internal class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, IEnumerable<ProductDto>>
{
    private readonly IProductRepository productRepository;
    private readonly IMapper mapper;

    public GetProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        this.productRepository = productRepository;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<IEnumerable<ProductDto>>(await productRepository.GetAll());
    }
}