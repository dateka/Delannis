using System;
using System.Threading.Tasks;
using FluentAssertions;
using TechTalk.SpecFlow;
using Ynov.Delannis.Domain.CartAggregate;
using Ynov.Delannis.Domain.CartAggregate.Ports;
using Ynov.Delannis.Domain.CartAggregate.Services;
using Ynov.Delannis.Domain.UserAggregate;
using Ynov.Delannis.Domain.UserAggregate.Ports;
using Ynov.Delannis.Specs.Drivers;
using Ynov.Delannis.Specs.Steps.UserAggregate;

namespace Ynov.Delannis.Specs.Steps.CartAggregate
{
    [Binding]
    public class EmptyCartDefinitions
    {
        private readonly IEmptyCartService _emptyCartService;
        private readonly ErrorDriver _errorDriver;
        private readonly ScenarioContext _scenarioContext;
        private readonly ICartRepository _cartRepository;
        private readonly IUserRepository _userRepository;
        private Cart? _cart;
        private User _user;
        
        public EmptyCartDefinitions(IEmptyCartService emptyCartService, ErrorDriver errorDriver, ScenarioContext scenarioContext, ICartRepository cartRepository, IUserRepository userRepository)
        {
            _emptyCartService = emptyCartService;
            _errorDriver = errorDriver;
            _scenarioContext = scenarioContext;
            _cartRepository = cartRepository;
            _userRepository = userRepository;
        }
        
        [When(@"I try to empty my cart")]
        public async Task WhenITryToEmptyMyCart()
        {
            //_user = _scenarioContext.Get<User>(UserDefinitions.LoggedUserKey);
            string userMail = _scenarioContext.Get<string>("LoggedUser");
            _user = await _userRepository.GetByEmailAsync(userMail);
            _cart = await _cartRepository.GetCartByUserEmailAsync(_user?.Email)!.ConfigureAwait(false);
        
            async Task<Cart> HandleAsync() =>
                await _emptyCartService.HandleAsync(_cart?.Id, _user?.Email).ConfigureAwait(false);

            await _errorDriver.TryExecuteAsync(HandleAsync).ConfigureAwait(false);
        }
        
        [Then(@"my cart should be empty")]
        public async Task WhenMyCartShouldBeEmpty()
        {
            Cart cart = await _cartRepository.GetCartByIdAndUserEmailAsync(_cart.Id, _user.Email).ConfigureAwait(false);
            cart.CartItems.Should().BeEmpty();
        }
    }
}