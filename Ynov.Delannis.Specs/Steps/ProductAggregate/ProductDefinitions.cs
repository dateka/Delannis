using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Ynov.Delannis.Domain.productAggregate;
using Ynov.Delannis.Domain.productAggregate.Ports;

namespace Ynov.Delannis.Specs.Steps.ProductAggregate
{
    [Binding]
    public class ProductDefinitions
    {
        private readonly IProductRepository _productRepository;

        public ProductDefinitions(IProductRepository productRepository) => _productRepository = productRepository;

        [Given(@"some products exists")]
        public async Task GivenSomeProductsExists(Table table)
        {
            IEnumerable<Product> products = table.CreateSet<Product>();

            foreach (Product product in products)
            {
                await _productRepository.AddAsync(product).ConfigureAwait(false);
                Product savedProduct = await _productRepository.GetByIdAsync(Int32.Parse(product.Id)).ConfigureAwait(false);

                savedProduct.Should().BeEquivalentTo(product);
            }
        }

        [Then(@"stock for ""(.*)"" should be ""(.*)""")]
        public async Task ThenStockForShouldBe(string productLabel, int stockQuantity)
        {
            Product savedProduct = await _productRepository.GetByProductLabelAsync(productLabel).ConfigureAwait(false);
            savedProduct.StockQuantity.Should().Be(stockQuantity);
        }
    }
}