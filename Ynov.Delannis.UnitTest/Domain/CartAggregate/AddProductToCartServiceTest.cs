using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Ynov.Delannis.Domain.CartAggregate;
using Ynov.Delannis.Domain.CartAggregate.Services;
using Ynov.Delannis.Domain.productAggregate;
using Ynov.Delannis.Domain.productAggregate.Ports;
using Ynov.Delannis.Domain.UserAggregate;
using Ynov.Delannis.Domain.UserAggregate.Ports;
using Ynov.Delannis.DomainShared.Core.Exceptions.ProductAggregate;
using Ynov.Delannis.DomainShared.Core.Exceptions.UserAggregate;
using Ynov.Delannis.UnitTest.Commons;

namespace Ynov.Delannis.UnitTest.Domain.CartAggregate
{
    public class AddProductToCartServiceTest : UnitTestFixture
    {
        private IAddProductToCartService _addProductToCartService;
        private IProductRepository _productRepository;
        private IUserRepository _userRepository;
        private IAuthenticationGateway _authenticationGateway;
        
        /*private UserDto _userLogged = new UserDto()
        {
            Email = "logged@email.com",
            IsLogged = true
        };*/
        
        private Product _product;

        private readonly Product _addedProduct = new Product()
        {
            Label = "Ryzen 5900x",
        };
        
        public AddProductToCartServiceTest(UnitTestConfiguration unitTestConf) : base(unitTestConf)
        {
            InitFixtureAsync().GetAwaiter().GetResult();
            _productRepository = GetImplementationFromService<IProductRepository>();
            _authenticationGateway = GetImplementationFromService<IAuthenticationGateway>();
            _userRepository = GetImplementationFromService<IUserRepository>();
            
            //_userRepository.AddAsync(elonMusk).GetAwaiter().GetResult();
        }
        
        protected sealed override async Task InitFixtureAsync()
        {
            await base.InitFixtureAsync();
            _addProductToCartService = GetImplementationFromService<IAddProductToCartService>();
            _userRepository = GetImplementationFromService<IUserRepository>();
            _productRepository = GetImplementationFromService<IProductRepository>();

            _product = new Product()
            {
                TaxedPrice = 599,
                TaxRate = 20,
                StockQuantity = 10,
                Label = "Ryzen 5900x",
                Id = 1.ToString()
            };
            await _productRepository.AddAsync(_product);
        }
        
       /* [Fact]
        public async Task AddProductToCartUseCase_UserIsNotLogged_ShouldThrowException()
        {
            Func<Task<Cart>> handleAsync = async () => await  _addProductToCartService.HandleAsync(new UserDto(), new Product(), 0);

            await handleAsync.Should().ThrowExactlyAsync<NotLoggedException>();
        }
    
        [Fact]
        public async Task AddProductToCartUseCase_UserAddTooMuchProducts_ShouldThrowException()
        {
            (_userRepository).AddUser(_userLogged);
            Func<Task<Cart>> handleAsync = async () => await  _addProductToCartService.HandleAsync(_userLogged, _addedProduct, 11);

            await handleAsync.Should().ThrowExactlyAsync<NotEnoughtStockException>();
        }
    
        [Fact]
        public async Task AddProductToCartUseCase_UserAddProductToCart_ShouldHaveCorrectItems()
        {
            (_userRepository).AddUser(_userLogged);
            Cart cart = await _addProductToCartService.HandleAsync(_userLogged, _addedProduct, 1);

            cart.CartItems.First().Label.Should().Be("Ryzen 5900x");
            cart.TotalWithTaxes.Should().Be(599);
        }
    
        [Fact]
        public async Task AddProductToCartUseCase_UserAddProductToCart_ShouldUpdateStockQuantity()
        {
            (_userRepository).AddUser(_userLogged);
            Cart cart = await _addProductToCartService.HandleAsync(_userLogged, _addedProduct, 1);

            Product product = await _productRepository.GetByProductLabelAsync("Ryzen 5900x");
            product.StockQuantity.Should().Be(9);
        }*/
    }
}