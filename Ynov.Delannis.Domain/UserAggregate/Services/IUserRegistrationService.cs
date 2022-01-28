using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Ynov.Delannis.Domain.UserAggregate.Ports;
using Ynov.Delannis.DomainShared.Core.Exceptions.UserAggregate;

namespace Ynov.Delannis.Domain.UserAggregate.Services
{
    public interface IUserRegistrationService
    {
        Task HandleAsync(string userName, string email, string password);
    }
    
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly IAuthenticationGateway _authenticationGateway;
        private readonly IUserRepository _userRepository;
        public UserRegistrationService(IAuthenticationGateway authenticationGateway, IUserRepository userRepository)
        {
            _authenticationGateway = authenticationGateway;
            _userRepository = userRepository;
        }

        public async Task HandleAsync(string username, string email, string password)
        {
            if (_authenticationGateway.IsAuthenticate())
            {
                throw new CantCreateAccountWhenLoggedException();
            }

            if (_userRepository.GetByEmailAsync(email).GetAwaiter().GetResult()?.Email == email)
            {
                throw new EmailAlreadyExistException();
            }
            
            if (_userRepository.GetByUserNameAsync(username)?.GetAwaiter().GetResult()?.UserName == username)
            {
                throw new UserNameAlreadyExistException();
            }
            
            if (Regex.IsMatch(email, ".*@.*\\.(com|fr)") == false)
            {
                throw new UnvalidEmailException();
            }
            
            // min 6 car
            if (Regex.IsMatch(username, "[a-z]{6}.*") == false)
            {
                throw new UnvalidUsernameException();
            }
            
            if (Regex.IsMatch(password, "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{8,}$") == false)
            {
                throw new UnvalidPasswordException();
            }

            await _userRepository.AddAsync(new User(username, email, password));
        }
    }
}