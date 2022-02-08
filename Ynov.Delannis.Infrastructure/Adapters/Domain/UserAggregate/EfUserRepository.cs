using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ynov.Delannis.Domain.UserAggregate;
using Ynov.Delannis.Domain.UserAggregate.Ports;
using Ynov.Delannis.Infrastructure.Adapters.Database;

namespace Ynov.Delannis.Infrastructure.Adapters.Domain.UserAggregate
{
    public class EfUserRepository : IUserRepository
    {
        private ApplicationContext _applicationContext;
        public EfUserRepository(ApplicationContext applicationContext) => _applicationContext = applicationContext;
        public async Task AddAsync(User user)
        {
            await _applicationContext.Users.AddAsync(user);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task<User?> GetByIdAsync(string userId)
        {
            return await _applicationContext.Users.SingleOrDefaultAsync(_ => _.Id == userId);
        }

        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await _applicationContext.Users.SingleOrDefaultAsync(_ => _.UserName == userName);
        }

        public async ValueTask<User> GetByEmailAsync(string email)
        {
            return await _applicationContext.Users
                .SingleOrDefaultAsync(_ => _.Email == email);
        }
    }
}