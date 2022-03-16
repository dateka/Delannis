using Ynov.Delannis.Domain.UserAggregate;
using Ynov.Delannis.Domain.UserAggregate.Ports;

namespace Ynov.Delannis.Infrastructure.Adapters.Domain.UserAggregate
{
    public class InMemoryAuthenticationGateway : IAuthenticationGateway
    {
        private User? _user;
        public void Authenticate(User? user)
        {
            _user = user;
            _user.IsLogged = true;
        }

        public bool IsAuthenticate()
        {
            if (_user != null && _user.IsLogged)
            {
                return _user is not null;
            }
            
            return false;
        } 

        public User? GetAuthenticatedUser() => _user;
    }
}