using System.Threading.Tasks;
using Ynov.Delannis.Domain.UserAggregate;
using Ynov.Delannis.Domain.UserAggregate.Ports;
using Ynov.Delannis.Domain.UserAggregate.Services;

namespace Ynov.Delannis.Application.UserAggregate
{
    public class UserService
    {
        private IUserRegistrationService _registrationService;
        private IUserRepository _userRepository;

        public UserService(IUserRegistrationService registrationService, IUserRepository userRepository)
        {
            _registrationService = registrationService;
            _userRepository = userRepository;
        }

        public async Task RegistrationAsync(string username, string email, string password)
        {
            await Task.Run(async () => await _registrationService.HandleAsync(username, email, password));
        }

        public async ValueTask<User?> GetByEmailAsync(string email) => await _userRepository.GetByEmailAsync(email);
    }
}