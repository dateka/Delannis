using System.Threading.Tasks;
using Ynov.Delannis.Domain.UserAggregate.Ports;

namespace Ynov.Delannis.Domain.UserAggregate.Services
{
    public interface IShoppingCartService
    {   
        Task<Product> HandleAsync(string name, float price, int quantity);
    }

    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IProductRepository _productRepository;

        public ShoppingCartService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> HandleAsync(string name, float price, int quantity)
        {
            Product product = await _productRepository.GetByNameAsync(name);

            return product;
        }
    }
}