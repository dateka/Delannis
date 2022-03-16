using System;
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
    public interface IUpdateCartItemService
    {
        Task HandleAsync(string? email, string productName, int quantity);
    }
    
    public class UpdateCartItemService : IUpdateCartItemService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IAuthenticationGateway _authenticationGateway;

        public UpdateCartItemService(IUserRepository userRepository, ICartRepository cartRepository, IProductRepository productRepository, IAuthenticationGateway authenticationGateway)
        {
            _userRepository = userRepository;
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _authenticationGateway = authenticationGateway;
        }

        public async Task HandleAsync(string? email, string productName, int quantity)
        {
            User user = await _userRepository.GetByEmailAsync(email);
            _authenticationGateway.Authenticate(user);

            if (_authenticationGateway.IsAuthenticate())
            {
                Cart? cart = await _cartRepository.GetCartByUserEmailAsync(user.Email);
                
                int finalQuantity = cart.UpdateCartItemQuantity(productName, quantity);
            
                Product product = await _productRepository.GetByProductLabelAsync(productName);
    
                if (finalQuantity > product.StockQuantity)
                {
                    throw new NotEnoughtStockException();
                }
                
                await _cartRepository.UpdateAsync(cart);
                
                if (quantity > 0)
                {
                    product.LessStockQuantity(quantity);
                } else
                {
                    product.AddStockQuantity(Math.Abs(quantity));
                }
                await _productRepository.UpdateAsync(product);
            }
            throw new NotLoggedException();
        }
    }
}