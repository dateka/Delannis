using Ynov.Delannis.Domain.UserAggregate;
using Ynov.Delannis.Domain.UserAggregate.Ports;

namespace Ynov.Delannis.Infrastructure.Adapters.Domain.UserAggregate
{
    public class InMemoryAuthenticationGateway : IAuthenticationGateway
    {
        private User _user;
        public void Authenticate(User user)
        {
            _user = user;
        }

        public bool IsAuthenticate()
        {
            return _user is not null;
        }
    }
}