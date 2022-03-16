using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Ynov.Delannis.Domain.CartAggregate;
using Ynov.Delannis.Domain.CartAggregate.Services;
using Ynov.Delannis.Domain.productAggregate;
using Ynov.Delannis.Domain.productAggregate.Ports;
using Ynov.Delannis.Domain.UserAggregate;
using Ynov.Delannis.Specs.Drivers;
using Ynov.Delannis.Specs.Steps.UserAggregate;

namespace Ynov.Delannis.Specs.Steps.CartAggregate
{
    [Binding]
    public class AddToCartDefinitions
    {
        public const string CartIdKey = "CartIdKey";
        public const string CartAttemptKey = "CartAttempt";
        private readonly IProductRepository _productRepository;
        private readonly ScenarioContext _scenarioContext;
        private IAddProductToCartService _addProductToCartService;
        private readonly ErrorDriver _errorDriver;

        public AddToCartDefinitions(IProductRepository productRepository, ScenarioContext scenarioContext,
            IAddProductToCartService addProductToCartService, ErrorDriver errorDriver)
        {
            _productRepository = productRepository;
            _scenarioContext = scenarioContext;
            _addProductToCartService = addProductToCartService;
            _errorDriver = errorDriver;
        }

        [When(@"I try to add ""(.*)"" quantity of ""(.*)""")]
        public async Task WhenITryToAddQuantityOf(int quantity, string productLabel)
        {
            Product product = await _productRepository.GetByProductLabelAsync(productLabel).ConfigureAwait(false);
            User user = _scenarioContext.Get<User>(UserDefinitions.LoggedUserKey);

            async Task<Cart> HandleAsync() =>
                await _addProductToCartService.HandleAsync(user, product, quantity).ConfigureAwait(false);

            Cart cart = await _errorDriver.TryExecuteAsync<Cart>(HandleAsync).ConfigureAwait(false);

            Cart cartAttempt = new Cart();
            cartAttempt.AddItem(product.Label, product.TaxedPrice, product.TaxRate, quantity);
            _scenarioContext.Add(CartIdKey, cart?.Id);
            _scenarioContext.Add(CartAttemptKey, cartAttempt);
        }
    }
}