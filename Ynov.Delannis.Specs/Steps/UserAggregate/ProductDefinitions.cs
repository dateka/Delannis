using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Ynov.Delannis.Domain.UserAggregate;
using Ynov.Delannis.Domain.UserAggregate.Ports;

namespace Ynov.Delannis.Specs.Steps.UserAggregate
{
    [Binding]
    public class ProductDefinitions
    {
        private readonly IProductRepository _productRepository;

        public ProductDefinitions(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [Given(@"the following products exist")]
        public async Task GivenTheFollowingProductsExist(Table table)
        {
            IEnumerable<ProductModel> products = table.CreateSet<ProductModel>();

            foreach (ProductModel productModel in products)
            {
                Product product = new Product(productModel.Name, productModel.Price, productModel.Quantity);
                await _productRepository.AddAsync(product);
                Product dbProduct = await _productRepository.GetByIdAsync(product.Id);
                dbProduct.Should().NotBeNull();
                dbProduct.Should().Be(product);
            }
        }
    }
    public class ProductModel
    {
        public string Name { get; set; } 
        public float Price { get; set; }
        public int Quantity { get; set; } 
    }
}