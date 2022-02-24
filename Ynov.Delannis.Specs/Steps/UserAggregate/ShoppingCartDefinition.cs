using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Ynov.Delannis.Domain.UserAggregate;
using Ynov.Delannis.Domain.UserAggregate.Ports;
using Ynov.Delannis.Domain.UserAggregate.Services;
using Ynov.Delannis.Specs.Drivers;

namespace Ynov.Delannis.Specs.Steps.UserAggregate
{
    [Binding]
    public class ShoppingCartDefinition
    {
        private readonly ErrorDriver _errorDriver;
        private readonly ShoppingCartService _shoppingCartService;
        private readonly IProductRepository _productRepository;

        public ShoppingCartDefinition(ErrorDriver errorDriver, ShoppingCartService shoppingCartService, IProductRepository productRepository)
        {
            _errorDriver = errorDriver;
            _shoppingCartService = shoppingCartService;
            _productRepository = productRepository;
        }

        [Then(@"The shopping cart should get updated")]
        public void ThenTheShoppingCartShouldGetUpdated()
        {
            ScenarioContext.StepIsPending();
        }

        [Then(@"The shopping cart quantity should be two and the price should be twice the initial price")]
        public void ThenTheShoppingCartQuantityShouldBeTwoAndThePriceShouldBeTwiceTheInitialPrice()
        {
            ScenarioContext.StepIsPending();
        }

        [When(@"I add one ""(.*)"" to my shopping cart")]
        public async Task WhenIAddOneToMyShoppingCart(string name)
        {
            Product product = await _productRepository.GetByNameAsync(name);
            await _errorDriver.TryExecuteAsync(async () =>
                await _shoppingCartService.HandleAsync(product.Name, product.Price, product.Quantity));
        }

        [When(@"I add ""(.*)"" twice to my shopping cart")]
        public async Task WhenIAddTwiceToMyShoppingCart(string name)
        {
            Product product = await _productRepository.GetByNameAsync(name);
            await _errorDriver.TryExecuteAsync(async () =>
                await _shoppingCartService.HandleAsync(product.Name, product.Price, product.Quantity));
        }

        [When(@"I add ""(.*)"" and ""(.*)"" to my shopping cart")]
        public async Task WhenIAddAndToMyShoppingCart(string pull, string pantalon)
        {
            Product product1 = await _productRepository.GetByNameAsync(pull);
            Product product2 = await _productRepository.GetByNameAsync(pantalon);
            
            await _errorDriver.TryExecuteAsync(async () =>
                await _shoppingCartService.HandleAsync(product1.Name, product1.Price, product1.Quantity));
            
            await _errorDriver.TryExecuteAsync(async () =>
                await _shoppingCartService.HandleAsync(product2.Name, product2.Price, product2.Quantity));
        }

        [When(@"I remove one ""(.*)"" from my shopping cart")]
        public async Task WhenIRemoveOneFromMyShoppingCart(string pull)
        {
            Product product = await _productRepository.GetByNameAsync(pull);
            await _productRepository.RemoveAsync(product);
        }
    }
}