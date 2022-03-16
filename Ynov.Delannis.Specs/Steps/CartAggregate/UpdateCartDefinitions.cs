using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Ynov.Delannis.Domain.CartAggregate;
using Ynov.Delannis.Domain.CartAggregate.Ports;
using Ynov.Delannis.Domain.CartAggregate.Services;
using Ynov.Delannis.Domain.UserAggregate;
using Ynov.Delannis.Specs.Drivers;
using Ynov.Delannis.Specs.Steps.UserAggregate;

namespace Ynov.Delannis.Specs.Steps.CartAggregate
{
    [Binding]
    public class UpdateCartDefinitions
    {
        private readonly ErrorDriver _errorDriver;
        private readonly IUpdateCartItemService _updateCartItemService;
        private readonly ScenarioContext _scenarioContext;
        private readonly ICartRepository _cartRepository;

        public UpdateCartDefinitions(ErrorDriver errorDriver, IUpdateCartItemService updateCartItemService, ScenarioContext scenarioContext, ICartRepository cartRepository)
        {
            _errorDriver = errorDriver;
            _updateCartItemService = updateCartItemService;
            _scenarioContext = scenarioContext;
            _cartRepository = cartRepository;
        }
        
        [When(@"I try to update ""(.*)"" by (.*)")]
        public async Task WhenITryToUpdateBy(string productName, int quantity)
        {
            User? user = _scenarioContext.Get<User>(UserDefinitions.LoggedUserKey);
            async Task HandleAsync() => await _updateCartItemService.HandleAsync(user?.Email, productName, quantity).ConfigureAwait(false);
            await _errorDriver.TryExecuteAsync(HandleAsync).ConfigureAwait(false);

            if (user is not null)
            {
                Cart? cart = await _cartRepository.GetCartByUserEmailAsync(user.Email).ConfigureAwait(false);
                _scenarioContext.Add(AddToCartDefinitions.CartIdKey, cart?.Id);
                _scenarioContext.Add(AddToCartDefinitions.CartAttemptKey, cart);
            }
        }
    }
}