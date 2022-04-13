using System.Collections.Immutable;
using System.Threading.Tasks;

namespace Ynov.Delannis.Domain.productAggregate.Ports
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task RemoveAsync(Product product);
        Task<Product> GetByIdAsync(string productId);
        Task<Product> GetByProductLabelAsync(string productName);
        Task UpdateAsync(Product product);
    }
}