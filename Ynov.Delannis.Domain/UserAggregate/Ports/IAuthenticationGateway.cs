namespace Ynov.Delannis.Domain.UserAggregate.Ports
{
    public interface IAuthenticationGateway
    {
        void Authenticate(User user);
        bool IsAuthenticate();
    }
}