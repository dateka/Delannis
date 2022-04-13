namespace Ynov.Delannis.Domain.UserAggregate.Dtos
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public bool IsLogged { get; set; }
    }
}