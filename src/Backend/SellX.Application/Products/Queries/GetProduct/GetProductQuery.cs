using SellX.Application.Configuration.Queries;
using SellX.Application.Products.Dtos;
using SellX.Domain.Products;

namespace SellX.Application.Products.Queries.GetProduct;

public record GetProductQuery(ProductId ProductId) : IQuery<ProductDto>;
