using System.Threading.Tasks;
using Mapster;
using Ynov.Delannis.Application.UserAggregate.Dtos;
using Ynov.Delannis.Domain.UserAggregate;
using Ynov.Delannis.Domain.UserAggregate.Ports;
using Ynov.Delannis.Domain.UserAggregate.Services;

namespace Ynov.Delannis.Application.UserAggregate
{
    public class UserService
    {
        private IUserRegistrationService _registrationService;
        private IUserLoginService _loginService;
        private IUserRepository _userRepository;

        public UserService(IUserRegistrationService registrationService, IUserRepository userRepository, IUserLoginService loginService)
        {
            _registrationService = registrationService;
            _userRepository = userRepository;
            _loginService = loginService;
        }

        public async Task RegistrationAsync(string username, string email, string password)
        {
            await _registrationService.HandleAsync(username, email, password);
            //await Task.Run(async () => await _registrationService.HandleAsync(username, email, password));
        }
        
        public async Task<UserDto> LoginAsync(string email, string password)
        {
            User user = await _loginService.HandleAsync(email, password);
            return user.Adapt<UserDto>();
        }

        public async ValueTask<UserDto?> GetByEmailAsync(string email)
        {
            User? user = await _userRepository.GetByEmailAsync(email);
            return user.Adapt<UserDto>();
        }
    }
}