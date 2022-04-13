using System.Threading.Tasks;
using Ynov.Delannis.Domain.CartAggregate;
using Ynov.Delannis.Domain.CartAggregate.Services;
using Ynov.Delannis.Domain.productAggregate;
using Ynov.Delannis.Domain.productAggregate.Services;
using Ynov.Delannis.Domain.UserAggregate;

namespace Ynov.Delannis.Application.CartAggregate
{
    public class CartService
    {
        private IAddProductToCartService _addProductToCartService;
        private IEmptyCartService _emptyCartService;
        private IUpdateCartItemService _updateCartItemService;

        public CartService(IAddProductToCartService addProductToCartService, IEmptyCartService emptyCartService, IUpdateCartItemService updateCartItemService)
        {
            _addProductToCartService = addProductToCartService;
            _emptyCartService = emptyCartService;
            _updateCartItemService = updateCartItemService;
        }

        public async Task<Cart> addItemToCartAsync(User user, Product product, int quantity)
        {
            return await _addProductToCartService.HandleAsync(user, product, quantity);
        }

        public async Task<Cart> DeleteItemFromCartAsync(string id, string email)
        {
            return await _emptyCartService.HandleAsync(id, email);
        }
        public async Task UpdateItemFromCartAsync(string email, string productName, int quantity)
        {
            await _updateCartItemService.HandleAsync(email, productName, quantity);
        }
    }
}