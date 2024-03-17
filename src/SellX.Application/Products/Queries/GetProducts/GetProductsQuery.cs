using SellX.Application.Configuration.Queries;
using SellX.Application.Products.Dtos;
using SellX.Domain.Providers;

namespace SellX.Application.Products.Queries.GetProduct;

public record GetProductsQuery(Guid? ProviderId) : IQuery<IEnumerable<ProductDto>>;
