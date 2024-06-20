using AutoMapper;
using SellX.Application.Products.Dtos;
using SellX.Domain.Products;
using SellX.Domain.Providers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductId, Guid>().ConstructUsing(o => o.Value);
        CreateMap<SizeId, Guid>().ConstructUsing(o => o.Value);
        CreateMap<ProviderId, Guid>().ConstructUsing(o => o.Value);
        
        CreateMap<Product, ProductDto>();
        CreateMap<Size, SizeDto>();
    }
}