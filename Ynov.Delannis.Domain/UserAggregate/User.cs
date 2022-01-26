using Ynov.Delannis.Domain.Common;

namespace Ynov.Delannis.Domain.UserAggregate
{
    public class User : EntityBase, IAggregateRoot
    {
        public string UserName { get; }
        public string Email { get;  }
        public string Password { get; }
        
        public User(string userModelUserName, string userModelEmail, string userModelPassword)
        {
            UserName = userModelUserName;
            Email = userModelEmail;
            Password = userModelPassword;
        }
    }
}