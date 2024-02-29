using Spaceship.Gateway.Shared.ValueObject;

namespace Spaceship.Gateway.Models.ValueObjects
{
    public class LoginModel : ValueObject
    {
        public LoginModel(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get;  set; }
        public string Password { get;  set; }
    }
}
