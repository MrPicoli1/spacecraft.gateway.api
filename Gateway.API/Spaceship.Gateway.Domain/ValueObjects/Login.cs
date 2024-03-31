using Flunt.Validations;
using Spaceship.Gateway.Shared.ValueObject;


namespace Spaceship.Gateway.Domain.ValueObjects
{
    public class Login : ValueObject
    {
        public Login(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; private set; }
        public string Password { get; private set; }
    }
}
