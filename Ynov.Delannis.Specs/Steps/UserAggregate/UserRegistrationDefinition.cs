using System.Threading.Tasks;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Ynov.Delannis.Domain.UserAggregate;
using Ynov.Delannis.Domain.UserAggregate.Ports;
using Ynov.Delannis.Domain.UserAggregate.Services;
using Ynov.Delannis.Specs.Drivers;

namespace Ynov.Delannis.Specs.Steps.UserAggregate
{
    [Binding]
    public class UserRegistrationDefinition
    {
        private UserModel _user;
        private readonly ErrorDriver _errorDriver;
        private readonly IUserRegistrationService _userRegistrationService;
        private readonly IUserRepository _userRepository;

        public UserRegistrationDefinition(ErrorDriver errorDriver, IUserRegistrationService userRegistrationService, IUserRepository userRepository)
        {
            _errorDriver = errorDriver;
            _userRegistrationService = userRegistrationService;
            _userRepository = userRepository;
        }
        
        [Given(@"my registration information")]
        public void GivenMyRegistrationInformation(Table table)
        {
            _user = table.CreateInstance<UserModel>();
        }

        [When(@"I create an account")]
        public async Task WhenICreateAnAccount()
        {
            await _errorDriver.TryExecuteAsync(async () =>
                await _userRegistrationService.HandleAsync(_user.UserName, _user.Email, _user.Password));
        }

        [Then(@"I should be notified with ""(.*)"" message")]
        public void ThenIShouldBeNotifiedWithMessage(string errorMessage)
        {
            _errorDriver.AssertExceptionWasRaisedWithMessage(errorMessage);
        }

        [Given(@"I set an unvalid password ""(.*)""")]
        public void GivenISetAnUnvalidPassword(string password)
        {
            _user.Password = password;
        }

        [Given(@"I set an unvalid email ""(.*)""")]
        public void GivenISetAnUnvalidEmail(string email)
        {
            _user.Email = email;
        }

        [Given(@"I set an unvalid userName ""(.*)""")]
        public void GivenISetAnUnvalidUserName(string username)
        {
            _user.UserName = username;
        }

        [Then(@"I should have an account")]
        public async Task ThenIShouldHaveAnAccount()
        {
            User exceptedUser = await _userRepository.GetByEmailAsync(_user.Email);
            exceptedUser.Should().NotBeNull();
            exceptedUser.Should().BeEquivalentTo(_user);
        }
    }
}