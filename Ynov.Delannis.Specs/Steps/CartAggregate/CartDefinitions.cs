using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Ynov.Delannis.Domain.CartAggregate;
using Ynov.Delannis.Domain.CartAggregate.Ports;
using Ynov.Delannis.Domain.UserAggregate;
using Ynov.Delannis.Specs.Steps.UserAggregate;

namespace Ynov.Delannis.Specs.Steps.CartAggregate
{
    [Binding]
    public class CartDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly ICartRepository _cartRepository;
        private User _user;
        private Cart _cart;

        public CartDefinitions(ScenarioContext scenarioContext, ICartRepository cartRepository)
        {
            _scenarioContext = scenarioContext;
            _cartRepository = cartRepository;
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
            int cartId = _scenarioContext.Get<int>(AddToCartDefinitions.CartIdKey);
            Cart cartAttempt = _scenarioContext.Get<Cart>(AddToCartDefinitions.CartAttemptKey);
            _user = _scenarioContext.Get<User>(UserDefinitions.LoggedUserKey);

            _cart = await _cartRepository.GetCartByIdAndUserEmailAsync(cartId, _user.Email).ConfigureAwait(false);

            _cart.CartItems.Should().BeEquivalentTo(cartAttempt.CartItems);
        }

        [Then(@"My cart should have total of ""(.*)""")]
        public async Task ThenMyCartShouldHaveTotalOf(decimal expectedTotal)
        {
            Cart cart = await _cartRepository.GetCartByIdAndUserEmailAsync(Int32.Parse(_cart.Id), _user.Email).ConfigureAwait(false);
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