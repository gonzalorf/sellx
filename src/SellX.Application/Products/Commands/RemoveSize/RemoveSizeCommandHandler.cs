using SellX.Application.Configuration.Commands;
using SellX.Application.Products.Commands.RemoveSize;
using SellX.Domain.Products;

namespace SellX.Application.Products.Handlers.RemoveSize
{
    public class RemoveSizeCommandHandler : ICommandHandler<RemoveSizeCommand>
    {
        private readonly IProductRepository productRepository;

        public RemoveSizeCommandHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task Handle(RemoveSizeCommand command, CancellationToken cancellationToken)
        {
            var product = await productRepository.GetById(new ProductId(command.ProductId));
            var size = product.Sizes.SingleOrDefault(s => s.Id == new SizeId(command.SizeId));

            product.RemoveSize(size);

            productRepository.Update(product);

            return;
        }
    }
}