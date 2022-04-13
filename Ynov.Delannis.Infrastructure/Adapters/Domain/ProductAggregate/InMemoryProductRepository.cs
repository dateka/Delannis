using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Ynov.Delannis.Domain.productAggregate;
using Ynov.Delannis.Domain.productAggregate.Ports;

namespace Ynov.Delannis.Infrastructure.Adapters.Domain.ProductAggregate
{
    public class InMemoryProductRepository : IProductRepository
    {
        private IImmutableSet<Product> _products = ImmutableHashSet<Product>.Empty;
        public Task AddAsync(Product product)
        {
            IImmutableSet<Product> immutableSet = _products.Add(product);
            _products = immutableSet;
            
            return Task.CompletedTask;
        }

        public Task RemoveAsync(Product product)
        {
            IImmutableSet<Product> immutableSet = _products.Remove(product);
            _products = immutableSet;
            
            return Task.CompletedTask;
        }

        public Task<Product> GetByIdAsync(string productId)
        {
            return Task.FromResult(_products.FirstOrDefault(_ => _.Id == productId));
        }

        public Task<Product> GetByProductLabelAsync(string productName)
        {
            return Task.FromResult(_products.FirstOrDefault(_ => _.Label == productName));
        }
        
        public Task UpdateAsync(Product product)
        {
            ICollection<Product> tempProducts = _products.Where(_ => _.Id != product.Id).ToList();
            tempProducts.Add(product);

            _products = tempProducts.ToImmutableHashSet();
        
            return Task.CompletedTask;
        }
    }
}