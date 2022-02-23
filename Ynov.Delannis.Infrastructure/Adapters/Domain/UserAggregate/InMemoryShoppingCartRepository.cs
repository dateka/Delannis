using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Ynov.Delannis.Domain.UserAggregate;
using Ynov.Delannis.Domain.UserAggregate.Ports;

namespace Ynov.Delannis.Infrastructure.Adapters.Domain.UserAggregate
{
    public class InMemoryShoppingCartRepository : IShoppingCartRepository
    {
        private IImmutableSet<Product> _products = ImmutableHashSet<Product>.Empty;
        
        public Task AddAsync(Product product)
        {
            IImmutableSet<Product> immutableSet = _products.Add(product);
            _products = immutableSet;
            
            return Task.CompletedTask;
        }

        public Task<Product?> GetByIdAsync(string productId)
        {
            return Task.FromResult(_products.FirstOrDefault(_ => _.Id == productId));
        }

        public Task<Product?> GetByNameAsync(string productName)
        {
            return Task.FromResult(_products.FirstOrDefault(_ => _.Name == productName));
        }
    }
}