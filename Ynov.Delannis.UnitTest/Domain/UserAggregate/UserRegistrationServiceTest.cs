using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using Ynov.Delannis.Domain.UserAggregate;
using Ynov.Delannis.Domain.UserAggregate.Ports;
using Ynov.Delannis.Domain.UserAggregate.Services;
using Ynov.Delannis.DomainShared.Core.Exceptions.UserAggregate;
using Ynov.Delannis.UnitTest.Commons;

namespace Ynov.Delannis.UnitTest.Domain.UserAggregate
{
    public class UserRegistrationServiceTest : UnitTestFixture
    {
        private readonly User elonMusk = new User("elonMusk", "elonMusk@tesla.com", "Azerty123&");
        private readonly IUserRegistrationService _registrationService;
        private readonly IAuthenticationGateway _authenticationGateway;
        private readonly IUserRepository _userRepository;
        
        public UserRegistrationServiceTest(UnitTestConfiguration unitTestConf) : base(unitTestConf)
        {
            InitFixtureAsync().GetAwaiter().GetResult();
            _registrationService = GetImplementationFromService<IUserRegistrationService>();
            _authenticationGateway = GetImplementationFromService<IAuthenticationGateway>();
            _userRepository = GetImplementationFromService<IUserRepository>();
        }
        
        [Fact]
        [Trait("Category", "Domain")]
        public async Task UserRegistrationService_WhenUserIsLogged_ShouldThrowCantCreateAccountWhenLoggedException()
        {
            _authenticationGateway.Authenticate(elonMusk);
            Func<Task> asyncAction = async () => await _registrationService.HandleAsync("azertyuiop", "toto@gmail.com", "Azerty123?");
            await asyncAction.Should().ThrowAsync<CantCreateAccountWhenLoggedException>();
        }
        
        [Fact]
        [Trait("Category", "Domain")]
        public async Task UserRegistrationService_WhenUserSetBadEmail_ShouldThrowUnvalidEmailException()
        {
            Func<Task> asyncAction = async () => await _registrationService.HandleAsync("azertyuiop", "elonMusktesla.com", "Azerty123?");
            await asyncAction.Should().ThrowAsync<UnvalidEmailException>();
        }
        
        [Fact]
        [Trait("Category", "Domain")]
        public async Task UserRegistrationService_WhenUserSetBadUsername_ShouldThrowUnvalidUsernameException()
        {
            Func<Task> asyncAction = async () => await _registrationService.HandleAsync("Toto", "elonMusk@tesla.com", "Azerty123?");
            await asyncAction.Should().ThrowAsync<UnvalidUsernameException>();
        }
        
        [Fact]
        [Trait("Category", "Domain")]
        public async Task UserRegistrationService_WhenUserSetBadPassword_ShouldThrowUnvalidPasswordException()
        {
            Func<Task> asyncAction = async () => await _registrationService.HandleAsync("azertyuiop", "elonMusk@tesla.com", "Azerty123");
            await asyncAction.Should().ThrowAsync<UnvalidPasswordException>();
        }
        
        [Fact]
        [Trait("Category", "Domain")]
        public async Task UserRegistrationService_WhenUserSetAnExistingEmail_ShouldThrowEmailAlreadyExistException()
        {
            await _userRepository.AddAsync(elonMusk);
            Func<Task> asyncAction = async () => await _registrationService.HandleAsync("azertyuiop", "elonMusk@tesla.com", "Azerty123?");
            await asyncAction.Should().ThrowAsync<EmailAlreadyExistException>();
        }
        
        [Fact]
        [Trait("Category", "Domain")]
        public async Task UserRegistrationService_WhenUserSetAnExistingUsername_ShouldThrowUsernameAlreadyExistException()
        {
            await _userRepository.AddAsync(elonMusk);
            Func<Task> asyncAction = async () => await _registrationService.HandleAsync("elonMusk", "damien@tesla.com", "Azerty123?");
            await asyncAction.Should().ThrowAsync<UserNameAlreadyExistException>();
        }
        
        [Fact]
        [Trait("Category", "Domain")]
        public async Task UserRegistrationService_WhenUserCreateAnAccount_ShouldReturnAnAccount()
        {
            await _registrationService.HandleAsync("damien02", "damien@gmail.com", "Azerty123?");

            User exceptedUser = await _userRepository.GetByEmailAsync("damien@gmail.com");
            
            exceptedUser.Should().NotBeNull();
            exceptedUser.Email.Should().BeEquivalentTo("damien@gmail.com");
            exceptedUser.Password.Should().BeEquivalentTo("Azerty123?");
            exceptedUser.UserName.Should().BeEquivalentTo("damien02");
        }
    }
}