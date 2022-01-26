using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Ynov.Delannis.Domain.UserAggregate;
using Ynov.Delannis.Domain.UserAggregate.Ports;

namespace Ynov.Delannis.Infrastructure.Adapters.Domain.UserAggregate
{
    public class InMemoryUserRepository : IUserRepository
    {
        private IImmutableSet<User> _users = ImmutableHashSet<User>.Empty;
        public Task AddAsync(User user)
        {
            IImmutableSet<User> immutableSet = _users.Add(user);
            _users = immutableSet;
            
            return Task.CompletedTask;
        }

        public Task<User> GetByIdAsync(string userId)
        {
            return Task.FromResult(_users.FirstOrDefault(_ => _.Id == userId));
        }

        public Task<User> GetByUserNameAsync(string userName)
        {
            return Task.FromResult(_users.FirstOrDefault(_ => _.UserName == userName));
        }

        public Task<User> GetByEmailAsync(string email)
        {
            return Task.FromResult(_users.FirstOrDefault(_ => _.Email == email));
        }
    }
}