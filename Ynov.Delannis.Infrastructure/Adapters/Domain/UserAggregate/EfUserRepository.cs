using System.Threading.Tasks;
using Ynov.Delannis.Domain.UserAggregate;
using Ynov.Delannis.Domain.UserAggregate.Ports;
using Ynov.Delannis.Infrastructure.Adapters.Domain.Database;

namespace Ynov.Delannis.Infrastructure.Adapters.Domain.UserAggregate
{
    public class EfUserRepository : IUserRepository
    {
        private ApplicationContext _applicationContext;
        public EfUserRepository(ApplicationContext applicationContext) => _applicationContext = applicationContext;
        public Task AddAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetByIdAsync(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetByUserNameAsync(string userName)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetByEmailAsync(string email)
        {
            throw new System.NotImplementedException();
        }
    }
}