using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Ynov.Delannis.Domain.CartAggregate;
using Ynov.Delannis.Domain.CartAggregate.Ports;
using Ynov.Delannis.Domain.UserAggregate;
using Ynov.Delannis.Domain.UserAggregate.Ports;
using Ynov.Delannis.Specs.Steps.UserAggregate;

namespace Ynov.Delannis.Specs.Steps.CartAggregate
{
    [Binding]
    public class CartDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly ICartRepository _cartRepository;
        private readonly IUserRepository _userRepository;
        private User _user;
        private Cart _cart;

        public CartDefinitions(ScenarioContext scenarioContext, ICartRepository cartRepository, IUserRepository userRepository)
        {
            _scenarioContext = scenarioContext;
            _cartRepository = cartRepository;
            _userRepository = userRepository;
        }
        
        [Given(@"user already have items")]
        public async Task GivenUserAlreadyHaveItems(Table table)
        {
            IEnumerable<UserItems> userItems = table.CreateSet<UserItems>();

            foreach (UserItems userItem in userItems)
            {
                Cart cart = new Cart
                {
                    Email = userItem.Email
                };
                cart.AddItem(userItem.Name, userItem.TaxedPrice, userItem.TaxRate, userItem.Quantity);
                await _cartRepository.AddAsync(cart).ConfigureAwait(false);
            }
        }

        [Then(@"I should have correct items in my cart")]
        public async Task ThenIShouldHaveCorrectItemsInMyCart()
        {
            string cartId = _scenarioContext.Get<string>(AddToCartDefinitions.CartIdKey);
            Cart cartAttempt = _scenarioContext.Get<Cart>(AddToCartDefinitions.CartAttemptKey);
            //string cartId = ScenarioContext.Current[AddToCartDefinitions.CartIdKey].ToString();
            //Cart cartAttempt = ScenarioContext.Current[AddToCartDefinitions.CartAttemptKey];
            string userMail =  _scenarioContext.Get<string>("LoggedUser");
            _user = await _userRepository.GetByEmailAsync(userMail);

            _cart = await _cartRepository.GetCartByIdAndUserEmailAsync(cartId, _user.Email).ConfigureAwait(false);

            if (_cart.CartItems.Count > 0)
            {
                _cart.CartItems.ElementAt(0).Label.Should().BeEquivalentTo(cartAttempt.CartItems.ElementAt(0).Label);
                _cart.CartItems.ElementAt(0).Quantity.Should().Be(cartAttempt.CartItems.ElementAt(0).Quantity);
            }
            else
            {
                _cart.CartItems.Should().BeEquivalentTo(cartAttempt.CartItems);
            }
        }
        [Then(@"My cart should have total of ""(.*)""")]
        public async Task ThenMyCartShouldHaveTotalOf(decimal expectedTotal)
        {
            Cart cart = await _cartRepository.GetCartByIdAndUserEmailAsync(_cart.Id, _user.Email).ConfigureAwait(false);
            cart.TotalWithTaxes.Should().Be(expectedTotal);
        }
    }
    
    public class UserItems
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public decimal TaxedPrice { get; set; }
        public decimal TaxRate { get; set; }
        public int Quantity { get; set; }
    }
}