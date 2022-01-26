using System.Threading.Tasks;

namespace Ynov.Delannis.Domain.UserAggregate.Ports
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> GetByIdAsync(string userId);
        Task<User> GetByUserNameAsync(string userName);
        Task<User> GetByEmailAsync(string email);
    }
}