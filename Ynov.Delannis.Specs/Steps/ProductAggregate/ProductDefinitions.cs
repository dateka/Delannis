using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Ynov.Delannis.Domain.productAggregate;
using Ynov.Delannis.Domain.productAggregate.Ports;
using Ynov.Delannis.Domain.UserAggregate.Ports;

namespace Ynov.Delannis.Specs.Steps.ProductAggregate
{
    [Binding]
    public class ProductDefinitions
    {
        private readonly IProductRepository _productRepository;

        public ProductDefinitions(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [Given(@"some products exists")]
        public async Task GivenSomeProductsExists(Table table)
        {
            IEnumerable<ProductModel> products = table.CreateSet<ProductModel>();

            foreach (ProductModel productModel in products)
            {
                Product product = new Product()
                {
                    Label = productModel.Label, 
                    TaxedPrice = productModel.TaxedPrice, 
                    TaxRate = productModel.TaxRate, 
                    StockQuantity = productModel.StockQuantity
                };
                
                await _productRepository.AddAsync(product);
                Product dbProduct = await _productRepository.GetByIdAsync(product.Id);

                dbProduct.Should().NotBeNull();
                dbProduct.Should().Be(product);
            }
        }

        [Then(@"stock for ""(.*)"" should be ""(.*)""")]
        public async Task ThenStockForShouldBe(string productLabel, int stockQuantity)
        {
            Product savedProduct = await _productRepository.GetByProductLabelAsync(productLabel).ConfigureAwait(false);
            savedProduct.StockQuantity.Should().Be(stockQuantity);
        }
    }
    
    public class ProductModel
    {
        public string Label { get; set; }
        public decimal TaxedPrice { get; set; }
        public decimal TaxRate { get; set; }
        public int StockQuantity { get; set; }
    }
}