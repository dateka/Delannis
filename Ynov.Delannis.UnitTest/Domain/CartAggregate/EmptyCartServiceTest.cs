using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Ynov.Delannis.Domain.CartAggregate;
using Ynov.Delannis.Domain.CartAggregate.Ports;
using Ynov.Delannis.Domain.CartAggregate.Services;
using Ynov.Delannis.Domain.productAggregate;
using Ynov.Delannis.Domain.productAggregate.Ports;
using Ynov.Delannis.Domain.UserAggregate.Dtos;
using Ynov.Delannis.DomainShared.Core.Exceptions.UserAggregate;
using Ynov.Delannis.UnitTest.Commons;

namespace Ynov.Delannis.UnitTest.Domain.CartAggregate
{
    public class EmptyCartServiceTest : UnitTestFixture
    {
        private ICartRepository _cartRepository;
        private UserDto _loggedUser = new UserDto()
        {
            Email = "logged@mail.com",
            IsLogged = true
        };

        private IEmptyCartService _emptyCartProductService;
        private Cart _cart;
        private IProductRepository _productRepository;
        private Product _product;

        public EmptyCartServiceTest(UnitTestConfiguration fixture) : base(fixture)
        {
            InitFixtureAsync().GetAwaiter().GetResult();
        }
    
        protected sealed override async Task InitFixtureAsync()
        {
            await base.InitFixtureAsync();
            _cartRepository = GetImplementationFromService<ICartRepository>();
            _productRepository = GetImplementationFromService<IProductRepository>();
            _emptyCartProductService = GetImplementationFromService<IEmptyCartService>();

            _product = new Product()
            {
                Label = "Ryzen 5900X",
                TaxedPrice = 599,
                TaxRate = 20,
                StockQuantity = 10
            };
            await _productRepository.AddAsync(_product);
            
            _cart = new Cart()
            {
                Email = _loggedUser.Email
            };
            
            _cart.AddItem(_product.Label, _product.TaxedPrice, _product.TaxRate, 1);
            
            await _cartRepository.AddAsync(_cart);
        }

        [Fact]
        public async Task EmptyCartUseCaseTest_NotLogged_ShouldThrowException()
        {
            Func<Task<Cart>> handleAsync = async () => await  _emptyCartProductService.HandleAsync(_cart.Id, "notloggedUser@email.com");

            await handleAsync.Should().ThrowExactlyAsync<NotLoggedException>();
        }
        
        [Fact]
        public async Task EmptyCartUseCaseTest_WhenEmptyCart_ShouldHaveNoItems()
        {
            //(_userWebService).AddUser(_loggedUser);
            Cart cart = await  _emptyCartProductService.HandleAsync(_cart.Id, _loggedUser.Email);

            cart = await _cartRepository.GetCartByIdAndUserEmailAsync(_cart.Id, _loggedUser.Email);

            cart.CartItems.Should().BeEmpty();
        }
        
        [Fact]
        public async Task EmptyCartUseCaseTest_WhenEmptyCart_ShouldChangeProductQuantity()
        {
            //(_userWebService).AddUser(_loggedUser);
            await  _emptyCartProductService.HandleAsync(_cart.Id, _loggedUser.Email);

            Product product = await _productRepository.GetByProductLabelAsync(_product.Label);

            product.StockQuantity.Should().Be(11);
        }
    }
}