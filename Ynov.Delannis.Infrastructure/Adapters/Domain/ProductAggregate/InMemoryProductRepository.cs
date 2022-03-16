using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Ynov.Delannis.Domain.productAggregate;
using Ynov.Delannis.Domain.productAggregate.Ports;

namespace Ynov.Delannis.Infrastructure.Adapters.Domain.ProductAggregate
{
    public class InMemoryProductRepository : IProductRepository
    {
        private IImmutableList<Product> _products = ImmutableArray<Product>.Empty;
        
        public IReadOnlyCollection<Product>? Products => JsonSerializer.Deserialize<IReadOnlyCollection<Product>>(JsonSerializer.Serialize(_products));

        public Task AddAsync(Product product)
        {
            _products = _products.Add(product);
            return Task.CompletedTask;
        }

        public ValueTask<Product> GetByIdAsync(int productId) => new ValueTask<Product>(Task.FromResult(Products.Single(_ => Int64.Parse(_.Id) == productId)));
        public ValueTask<Product> GetByProductLabelAsync(string productName) => new ValueTask<Product>(Task.FromResult(Products.Single(_ => _.Label == productName)));

        public Task UpdateAsync(Product product)
        {
            ICollection<Product> tempProducts = _products.Where(_ => _.Id != product.Id).ToList();
            tempProducts.Add(product);

            _products = tempProducts.ToImmutableList();
        
            return Task.CompletedTask;
        }
    }
}