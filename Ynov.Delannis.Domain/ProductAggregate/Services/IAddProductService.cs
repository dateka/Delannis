using System.Threading.Tasks;
using Ynov.Delannis.Domain.productAggregate.Ports;

namespace Ynov.Delannis.Domain.productAggregate.Services
{
    public interface IAddProductService
    {
        Task<Product> HandleAsync(Product product);
    }

    public class AddProductService : IAddProductService
    {
        private IProductRepository _productRepository;

        public AddProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> HandleAsync(Product product)
        {
            await _productRepository.AddAsync(product);
            return product;
        }
    }
}