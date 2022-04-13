using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Ynov.Delannis.Domain.CartAggregate;
using Ynov.Delannis.Domain.CartAggregate.Ports;
using Ynov.Delannis.Domain.CartAggregate.Services;
using Ynov.Delannis.Domain.productAggregate;
using Ynov.Delannis.Domain.productAggregate.Ports;
using Ynov.Delannis.Domain.UserAggregate;
using Ynov.Delannis.Domain.UserAggregate.Ports;
using Ynov.Delannis.DomainShared.Core.Exceptions.CartAggregate;
using Ynov.Delannis.DomainShared.Core.Exceptions.ProductAggregate;
using Ynov.Delannis.DomainShared.Core.Exceptions.UserAggregate;
using Ynov.Delannis.UnitTest.Commons;

namespace Ynov.Delannis.UnitTest.Domain.CartAggregate
{
    public class UpdateCartItemServiceTest : UnitTestFixture
    {
        private IUpdateCartItemService _updateCartItemService;
        private IProductRepository _productRepository;
        private ICartRepository _cartRepository;
        private IUserRepository _userRepository;
        private IAuthenticationGateway _authenticationGateway;
        
        private  User _loggedUser = new User("elonMusk", "elonMusk@tesla.com", "Azerty123&");
        private  User _notLoggedUser = new User("billGate", "billgate@microsoft.com", "Azerty123&");

        private Product _product;

        private readonly Product _addedProduct = new Product()
        {
            Label = "Ryzen 5900x",
        };


        protected sealed override async Task InitFixtureAsync()
        {
            await base.InitFixtureAsync();
            _updateCartItemService = GetImplementationFromService<IUpdateCartItemService>();
            _productRepository = GetImplementationFromService<IProductRepository>();
            _cartRepository = GetImplementationFromService<ICartRepository>();
            _userRepository = GetImplementationFromService<IUserRepository>();
            _authenticationGateway = GetImplementationFromService<IAuthenticationGateway>();

            _product = new Product()
            {
                TaxedPrice = 599,
                TaxRate = 20,
                StockQuantity = 10,
                Label = "Ryzen 5900x",
                Id = 1.ToString()
            };
            await _productRepository.AddAsync(_product);

            await _userRepository.AddAsync(_loggedUser);
            await _userRepository.AddAsync(_notLoggedUser);
            _authenticationGateway.Authenticate(_loggedUser);
            
            Cart cart = new Cart()
            {
                Email = _loggedUser.Email,
                Id = 1.ToString()
            };

            cart.AddItem(_product.Label, _product.TaxedPrice, _product.TaxRate, 1);
            await _cartRepository.AddAsync(cart);
        }

        public UpdateCartItemServiceTest(UnitTestConfiguration fixture) : base(fixture)
        {
            InitFixtureAsync().GetAwaiter().GetResult();
        }

        [Fact]
        public async Task UpdateCartItemUseCase_UserIsNotLogged_ShouldThrowException()
        {
            Func<Task> handleAsync = async () => 
                await _updateCartItemService.HandleAsync(_notLoggedUser.Email, _product.Label, 2);

            await handleAsync.Should().ThrowExactlyAsync<NotLoggedException>();
        }

        [Fact]
        public async Task UpdateCartItemUseCase_UserIsLoggedButUpdateBadProduct_ShouldThrowException()
        {
            Func<Task> handleAsync = async () =>
                await _updateCartItemService.HandleAsync(_loggedUser.Email, "Ryzen 3600", 2);

            await handleAsync.Should().ThrowExactlyAsync<CartDoesNotContainItemException>();
        }

        
        [Fact]
        public async Task UpdateCartItemUseCase_UserIsLoggedButUpdateTooMuchQuantity_ShouldThrowException()
        {
            Func<Task> handleAsync = async () =>
                await _updateCartItemService.HandleAsync(_loggedUser.Email, _product.Label, 12);

            await handleAsync.Should().ThrowExactlyAsync<NotEnoughtStockException>();
        }
        
        [Fact]
        public async Task UpdateCartItemUseCase_UpdateQuantity_ShouldUpdateCartItem()
        {
            int quantity = 2;
            await _updateCartItemService.HandleAsync(_loggedUser.Email, _product.Label, quantity);

            Cart? _cart = await _cartRepository.GetCartByUserEmailAsync(_loggedUser.Email);

            CartItem cartItem = _cart.CartItems.First(_ => _.Label == _product.Label);
            cartItem.Quantity.Should().Be(3);
            _cart.TotalWithTaxes.Should().Be(1797);

            Product product = await _productRepository.GetByProductLabelAsync(_product.Label);
            product.StockQuantity.Should().Be(8);
        }
        
        [Fact]
        public async Task UpdateCartItemUseCase_UpdateQuantityToZero_ShouldHaveEmptyCartItem()
        {
            int quantity = -1;
            await _updateCartItemService.HandleAsync(_loggedUser.Email, _product.Label, quantity);

            Cart? _cart = await _cartRepository.GetCartByUserEmailAsync(_loggedUser.Email);

            _cart.CartItems.Should().BeEmpty();
            _cart.TotalWithTaxes.Should().Be(0);

            Product product = await _productRepository.GetByProductLabelAsync(_product.Label);
            product.StockQuantity.Should().Be(11);
        }
        
    }
}