using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Ynov.Delannis.Domain.UserAggregate;
using Ynov.Delannis.Domain.UserAggregate.Ports;

namespace Ynov.Delannis.Specs.Steps.UserAggregate
{
    [Binding]
    public class UserDefinitions
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationGateway _authenticationGateway;

        public UserDefinitions(IUserRepository userRepository, IAuthenticationGateway authenticationGateway)
        {
            _userRepository = userRepository;
            _authenticationGateway = authenticationGateway;
        }
        
        [Given(@"a logged user as ""(.*)""")]
        public async Task GivenALoggedUserAs(string userName)
        {
            User user = await _userRepository.GetByUserNameAsync(userName);
            _authenticationGateway.Authenticate(user);
        }
        
        [Given(@"the following users exist")]
        public async Task GivenTheFollowingUsersExist(Table table)
        {
            IEnumerable<UserModel> users = table.CreateSet<UserModel>();

            foreach (UserModel userModel in users)
            {
                User user = new User(userModel.UserName, userModel.Email, userModel.Password);
                await _userRepository.AddAsync(user);
                User dbUser = await _userRepository.GetByIdAsync(user.Id);
                dbUser.Should().NotBeNull();
                dbUser.Should().Be(user);
            }
        }
    }
    
    public class UserModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}