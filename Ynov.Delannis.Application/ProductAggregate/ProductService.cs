using System.Drawing;
using System.Threading.Tasks;
using Mapster;
using Ynov.Delannis.Domain.productAggregate;
using Ynov.Delannis.Domain.productAggregate.Services;

namespace Ynov.Delannis.Application.ProductAggregate
{
    public class ProductService
    {
        private IAddProductService _addProductService;
        private IRemoveProductService _removeProductService;

        public ProductService(IAddProductService addProductService, IRemoveProductService removeProductService)
        {
            _addProductService = addProductService;
            _removeProductService = removeProductService;
        }
        
        public async Task<Product> AddProductAsync(Product product)
        {
            await _addProductService.HandleAsync(product);
            return product;
        }
        
        public async Task<Product> DeleteProductAsync(Product product)
        {
            await _removeProductService.HandleAsync(product);
            return product;
        }
    }
}