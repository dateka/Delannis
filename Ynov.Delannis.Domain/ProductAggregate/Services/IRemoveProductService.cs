using System.Threading.Tasks;
using Ynov.Delannis.Domain.productAggregate.Ports;

namespace Ynov.Delannis.Domain.productAggregate.Services
{
    public interface IRemoveProductService
    {
        Task<Product> HandleAsync(Product product);
    }

    public class RemoveProductService : IRemoveProductService
    {
        private IProductRepository _productRepository;

        public RemoveProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> HandleAsync(Product product)
        {
            await _productRepository.RemoveAsync(product);
            return product;
        }
    }
}