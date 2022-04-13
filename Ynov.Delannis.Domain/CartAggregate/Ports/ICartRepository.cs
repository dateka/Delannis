using System.Threading.Tasks;

namespace Ynov.Delannis.Domain.CartAggregate.Ports
{
    public interface ICartRepository
    {
        Task<Cart> GetCartByIdAndUserEmailAsync(string cartId, string? userEmail);
        Task AddAsync(Cart cart);
        Task UpdateAsync(Cart cart);
        Task<Cart?> GetCartByUserEmailAsync(string? userEmail);
    }
}