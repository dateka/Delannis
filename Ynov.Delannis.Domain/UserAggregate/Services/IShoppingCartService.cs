using System.Threading.Tasks;
using Ynov.Delannis.Domain.UserAggregate.Ports;

namespace Ynov.Delannis.Domain.UserAggregate.Services
{
    public interface IShoppingCartService
    {   
        Task<Product> HandleAsync(string name, float price);
    }

    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<Product> HandleAsync(string name, float price)
        {
            Product product = await _shoppingCartRepository.GetByNameAsync(name);

            return product;
        }
    }
}