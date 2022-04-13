using System.Threading.Tasks;
using Ynov.Delannis.Domain.CartAggregate.Ports;
using Ynov.Delannis.Domain.productAggregate;
using Ynov.Delannis.Domain.productAggregate.Ports;
using Ynov.Delannis.Domain.UserAggregate;
using Ynov.Delannis.Domain.UserAggregate.Ports;
using Ynov.Delannis.DomainShared.Core.Exceptions.ProductAggregate;
using Ynov.Delannis.DomainShared.Core.Exceptions.UserAggregate;

namespace Ynov.Delannis.Domain.CartAggregate.Services
{
    public interface IAddProductToCartService
    {
        Task<Cart> HandleAsync(User user, Product product, int quantity);
    }

    public class AddProductToCartService : IAddProductToCartService
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly IAuthenticationGateway _authenticationGateway;
        private readonly ICartRepository _cartRepository;
        
        public AddProductToCartService(IUserRepository userRepository, IProductRepository productRepository, ICartRepository cartRepository, IAuthenticationGateway authenticationGateway)
        {
            _userRepository = userRepository;
            _productRepository = productRepository;
            _cartRepository = cartRepository;
            _authenticationGateway = authenticationGateway;
        }
        
        public async Task<Cart> HandleAsync(User user, Product product, int quantity)
        {
            //user = await _userRepository.GetByEmailAsync(user?.Email);
            //_authenticationGateway.Authenticate(user);
            if (user.IsLogged)
            {
                product = await _productRepository.GetByProductLabelAsync(product.Label);

                Cart cart = await CreateCartAndSaveAsync(user, product, quantity);

                if (quantity > product.StockQuantity)
                {
                    throw new NotEnoughtStockException();
                }
        
                product.LessStockQuantity(quantity);
                await _productRepository.UpdateAsync(product);

                return cart;   
            }
            throw new NotLoggedException();
        }
        
        private async Task<Cart> CreateCartAndSaveAsync(User user, Product product, int quantity)
        {
            Cart cart = new Cart()
            {
                Email = user.Email
            };

            cart.AddItem(product.Label, product.TaxedPrice, product.TaxRate, quantity);

            await _cartRepository.AddAsync(cart);
            return cart;
        }
    }
}