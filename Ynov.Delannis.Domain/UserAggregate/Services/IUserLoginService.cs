using System.Threading.Tasks;
using Ynov.Delannis.Domain.UserAggregate.Ports;
using Ynov.Delannis.DomainShared.Core.Exceptions.UserAggregate;

namespace Ynov.Delannis.Domain.UserAggregate.Services
{
    public interface IUserLoginService
    {
        Task<User> HandleAsync(string email, string password);
    }
    
    public class UserLoginService : IUserLoginService
    {
        private readonly IAuthenticationGateway _authenticationGateway;
        private readonly IUserRepository _userRepository;

        public UserLoginService(IAuthenticationGateway authenticationGateway, IUserRepository userRepository)
        {
            _authenticationGateway = authenticationGateway;
            _userRepository = userRepository;
        }

        public async Task<User> HandleAsync(string email, string password)
        {
            if (_authenticationGateway.IsAuthenticate())
            {
                throw new CantLogAccountWhenLoggedException();
            }

            User user = await _userRepository.GetByEmailAsync(email);

            if (user is null)
            {
                throw new UserNotFoundException();
            }
            
            if (user.Password != password)
            {
                throw new UserNotFoundException();
            }
            
            _authenticationGateway.Authenticate(user);
            return user;
        }
    }
}