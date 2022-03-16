using System.Threading.Tasks;

namespace Ynov.Delannis.Domain.productAggregate.Ports
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        ValueTask<Product> GetByIdAsync(int productId);
        ValueTask<Product> GetByProductLabelAsync(string productName);
        Task UpdateAsync(Product product);
    }
}