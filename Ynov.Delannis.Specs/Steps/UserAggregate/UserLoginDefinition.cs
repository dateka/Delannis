using System.Threading.Tasks;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Ynov.Delannis.Domain.UserAggregate.Ports;
using Ynov.Delannis.Domain.UserAggregate.Services;
using Ynov.Delannis.Specs.Drivers;

namespace Ynov.Delannis.Specs.Steps.UserAggregate
{
    [Binding]
    public class UserLoginDefinition
    {
        private UserModel _user;
        private IAuthenticationGateway _authentication;
        private IUserLoginService _userLoginService;
        private ErrorDriver _errorDriver;
        
        public UserLoginDefinition(ErrorDriver errorDriver, IAuthenticationGateway authentication, IUserLoginService userLoginService)
        {
            _authentication = authentication;
            _userLoginService = userLoginService;
            _errorDriver = errorDriver;
        }
        
        [Given(@"my login information")]
        public void GivenMyLoginInformation(Table table)
        {
            _user = table.CreateInstance<UserModel>();
        }
        
        [When(@"I log into my account")]
        public async Task WhenILogIntoMyAccount()
        {
            await _errorDriver.TryExecuteAsync(async () =>
                await _userLoginService.HandleAsync(_user.Email, _user.Password));
        }
        
        [Then(@"I should be connect")]
        public void ThenIShouldBeConnect()
        {
            _authentication.IsAuthenticate().Should().BeTrue();
            _authentication.GetAuthenticatedUser()?.Email.Should().Be(_user.Email);
        }
    }
}