using System.Threading.Tasks;

namespace Ynov.Delannis.Domain.CartAggregate.Ports
{
    public interface ICartRepository
    {
        ValueTask<Cart> GetCartByIdAndUserEmailAsync(int cartId, string? userEmail);
        Task AddAsync(Cart cart);
        Task UpdateAsync(Cart cart);
        ValueTask<Cart?> GetCartByUserEmailAsync(string? userEmail);
    }
}