using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ynov.Delannis.Domain.UserAggregate;
using Ynov.Delannis.Domain.UserAggregate.Ports;
using Ynov.Delannis.Infrastructure.Adapters.Database;

namespace Ynov.Delannis.Infrastructure.Adapters.Domain.UserAggregate
{
    public class EfProductRepository : IProductRepository
    {
        private ApplicationContext _applicationContext;

        public EfProductRepository(ApplicationContext applicationContext) => _applicationContext = applicationContext;

        public async Task AddAsync(Product product)
        {
            await _applicationContext.Products.AddAsync(product);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(Product product)
        {
            //await _applicationContext.Products.RemoveAsync(product);
            _applicationContext.Products.Remove(product);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task<Product?> GetByIdAsync(string productId)
        {
            return await _applicationContext.Products.SingleOrDefaultAsync(_ => _.Id == productId);
        }

        public async Task<Product?> GetByNameAsync(string productName)
        {
            return await _applicationContext.Products.SingleOrDefaultAsync(_ => _.Id == productName);
        }
    }
}