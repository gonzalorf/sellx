using SellX.Application.Configuration.Queries;
using SellX.Domain.Products;

namespace NanoBlogEngine.Application.Products.Queries.GetProduct;

public record GetProductQuery(ProductId ProductId) : IQuery<ProductDto>;
