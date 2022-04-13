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
using Ynov.Delannis.Domain.UserAggregate.Dtos;
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

        private UserDto _userLogged = new UserDto()
        {
            Email = "logged@email.com",
            IsLogged = true
        };

        //private UserWebServiceMock _userWebService;
        private Product _product;

        private readonly Product _addedProduct = new Product()
        {
            Label = "Ryzen 5900x",
        };


        protected sealed override async Task InitFixtureAsync()
        {
            await base.InitFixtureAsync();
            _updateCartItemService = GetImplementationFromService<IUpdateCartItemService>();
            //_userWebService = (UserWebServiceMock)GetImplementationFromService<IUserWebService>();
            _productRepository = GetImplementationFromService<IProductRepository>();
            _cartRepository = GetImplementationFromService<ICartRepository>();

            _product = new Product()
            {
                TaxedPrice = 599,
                TaxRate = 20,
                StockQuantity = 10,
                Label = "Ryzen 5900x",
                Id = 1.ToString()
            };
            await _productRepository.AddAsync(_product);

            Cart cart = new Cart()
            {
                Email = _userLogged.Email,
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
            Func<Task> handleAsync = async () => await _updateCartItemService.HandleAsync(string.Empty, _product.Label, 2);

            await handleAsync.Should().ThrowExactlyAsync<NotLoggedException>();
        }

        [Fact]
        public async Task UpdateCartItemUseCase_UserIsLoggedButUpdateBadProduct_ShouldThrowException()
        {
            //(_userWebService).AddUser(_userLogged);

            Func<Task> handleAsync = async () =>
                await _updateCartItemService.HandleAsync(_userLogged.Email, "Ryzen 3600", 2);

            await handleAsync.Should().ThrowExactlyAsync<CartDoesNotContainItemException>();
        }

        
        [Fact]
        public async Task UpdateCartItemUseCase_UserIsLoggedButUpdateTooMuchQuantity_ShouldThrowException()
        {
            //(_userWebService).AddUser(_userLogged);

            Func<Task> handleAsync = async () =>
                await _updateCartItemService.HandleAsync(_userLogged.Email, _product.Label, 12);

            await handleAsync.Should().ThrowExactlyAsync<NotEnoughtStockException>();
        }
        
        [Fact]
        public async Task UpdateCartItemUseCase_UpdateQuantity_ShouldUpdateCartItem()
        {
            //(_userWebService).AddUser(_userLogged);
            int quantity = 2;
            await _updateCartItemService.HandleAsync(_userLogged.Email, _product.Label, quantity);

            Cart? _cart = await _cartRepository.GetCartByUserEmailAsync(_userLogged.Email);

            CartItem cartItem = _cart.CartItems.First(_ => _.Label == _product.Label);
            cartItem.Quantity.Should().Be(3);
            _cart.TotalWithTaxes.Should().Be(1797);

            Product product = await _productRepository.GetByProductLabelAsync(_product.Label);
            product.StockQuantity.Should().Be(8);
        }
        
        [Fact]
        public async Task UpdateCartItemUseCase_UpdateQuantityToZero_ShouldHaveEmptyCartItem()
        {
            //(_userWebService).AddUser(_userLogged);
            int quantity = -1;
            await _updateCartItemService.HandleAsync(_userLogged.Email, _product.Label, quantity);

            Cart? _cart = await _cartRepository.GetCartByUserEmailAsync(_userLogged.Email);

            _cart.CartItems.Should().BeEmpty();
            _cart.TotalWithTaxes.Should().Be(0);

            Product product = await _productRepository.GetByProductLabelAsync(_product.Label);
            product.StockQuantity.Should().Be(11);
        }
        
    }
}