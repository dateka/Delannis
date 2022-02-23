using System.Threading.Tasks;

namespace Ynov.Delannis.Domain.UserAggregate.Ports
{
    public interface IShoppingCartRepository
    {
        Task AddAsync(Product product);
        Task<Product?> GetByIdAsync(string productId);
        Task<Product?> GetByNameAsync(string productName);
    }
}