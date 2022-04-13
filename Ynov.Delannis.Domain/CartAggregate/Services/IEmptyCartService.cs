using System.Collections.Generic;
using System.Threading.Tasks;
using Ynov.Delannis.Domain.CartAggregate.Ports;
using Ynov.Delannis.Domain.productAggregate;
using Ynov.Delannis.Domain.productAggregate.Ports;
using Ynov.Delannis.Domain.UserAggregate;
using Ynov.Delannis.Domain.UserAggregate.Ports;
using Ynov.Delannis.DomainShared.Core.Exceptions.UserAggregate;

namespace Ynov.Delannis.Domain.CartAggregate.Services
{
    public interface IEmptyCartService
    {
        Task<Cart> HandleAsync(string id, string email);
    }

    public class EmptyCartService : IEmptyCartService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IAuthenticationGateway _authenticationGateway;

        public EmptyCartService(IUserRepository userRepository, ICartRepository cartRepository, IProductRepository productRepository, IAuthenticationGateway authenticationGateway)
        {
            _userRepository = userRepository;
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _authenticationGateway = authenticationGateway;
        }

        public async Task<Cart> HandleAsync(string id, string email)
        {
            User user = await _userRepository.GetByEmailAsync(email);
            _authenticationGateway.Authenticate(user);

            if (_authenticationGateway.IsAuthenticate())
            {
                Cart cart = await _cartRepository.GetCartByIdAndUserEmailAsync(id, email).ConfigureAwait(false);

                List<CartItem> cartItems = cart.EmptyItems();
                await _cartRepository.UpdateAsync(cart);

                foreach (CartItem cartItem in cartItems)
                {
                    Product product = await _productRepository.GetByProductLabelAsync(cartItem.Label);
                    product.AddStockQuantity(cartItem.Quantity);
                    await _productRepository.UpdateAsync(product);
                }
                return cart;
            }
            throw new NotLoggedException();
        }
    }
}