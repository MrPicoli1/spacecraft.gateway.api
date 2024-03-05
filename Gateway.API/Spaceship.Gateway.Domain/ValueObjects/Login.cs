using Flunt.Validations;
using Spaceship.Gateway.Shared.ValueObject;
using System.IO;

namespace Spaceship.Gateway.Domain.ValueObjects
{
    public class Login : ValueObject
    {
        public Login(string username, string password)
        {
            Username = username;
            Password = password;

            AddNotifications(new Contract<Login>()
            .Requires()
                .IsGreaterThan(Username, 3, "Username deve conter pelo menos 3 Caracteres")
                .IsGreaterThan(Password, 3, "Password deve conter pelo menos 3 Caracteres"));

        }

        public string Username { get; private set; }
        public string Password { get; private set; }
    }
}
