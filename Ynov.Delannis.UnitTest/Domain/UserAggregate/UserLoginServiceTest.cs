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
    public class UserLoginServiceTest : UnitTestFixture
    {
        private readonly User elonMusk = new User("elonMusk", "elonMusk@tesla.com", "Azerty123&");
        
        private readonly IUserLoginService _loginService;
        private readonly IAuthenticationGateway _authenticationGateway;
        private readonly IUserRepository _userRepository;
        
        public UserLoginServiceTest(UnitTestConfiguration unitTestConf) : base(unitTestConf)
        {
            InitFixtureAsync().GetAwaiter().GetResult();
            _loginService = GetImplementationFromService<IUserLoginService>();
            _authenticationGateway = GetImplementationFromService<IAuthenticationGateway>();
            _userRepository = GetImplementationFromService<IUserRepository>();
            
            _userRepository.AddAsync(elonMusk).GetAwaiter().GetResult();
        }
        
        [Fact]
        [Trait("Category", "Domain")]
        public async Task UserLoginService_WhenUserIsLogged_ShouldThrowCantLogAccountWhenLoggedException()
        {
            _authenticationGateway.Authenticate(elonMusk);
            Func<Task> asyncAction = async () => 
                await _loginService.HandleAsync("elonMusk@tesla.com", "Azerty123&");
            
            await asyncAction.Should().ThrowAsync<CantLogAccountWhenLoggedException>();
        }
        
        [Fact]
        [Trait("Category", "Domain")]
        public async Task UserLoginService_WhenSetBadEmail_ShouldThrowUserNotFoundLoggedException()
        {
            Func<Task> asyncAction = async () =>
                await _loginService.HandleAsync("elonMusk@teslow.com", "Azerty123&");

            await asyncAction.Should().ThrowAsync<UserNotFoundException>();
        }
        
        [Fact]
        [Trait("Category", "Domain")]
        public async Task UserLoginService_WhenSetBadPassword_ShouldThrowUserNotFoundLoggedException()
        {
            Func<Task> asyncAction = async () =>
                await _loginService.HandleAsync("elonMusk@tesla.com", "2zerty123&*");

            await asyncAction.Should().ThrowAsync<UserNotFoundException>();
        }
        
        [Fact]
        [Trait("Category", "Domain")]
        public async Task UserLoginService_ShouldBeLogged()
        {
            await _loginService.HandleAsync("elonMusk@tesla.com", "Azerty123&");

            _authenticationGateway.IsAuthenticate().Should().BeTrue();
            _authenticationGateway.GetAuthenticatedUser().Should().Be(elonMusk);
        }
    }
}