using SellX.Application.Configuration.Commands;
using SellX.Application.Products.Commands.AddSize;
using SellX.Domain.Products;

namespace SellX.Application.Products.Handlers.AddSize
{
    public class AddSizeCommandHandler : ICommandHandler<AddSizeCommand, SizeId>
    {
        private readonly IProductRepository productRepository;

        public AddSizeCommandHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<SizeId> Handle(AddSizeCommand request, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetById(request.ProductId);

            var size = Size.CreateSize(request.Name, request.Code, request.Price, request.StrikethroughPrice);
            product.AddSize(size);

            productRepository.Update(product);

            return size.Id;
        }
    }
}