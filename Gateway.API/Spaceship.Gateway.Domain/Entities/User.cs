using Spaceship.Gateway.Domain.ValueObjects;
using Spaceship.Gateway.Shared.Entities;

namespace Spaceship.Gateway.Domain.Entities
{
    public class User : Entity
    {
        public User(Login login, Email email, Address address, Material material)
        {
            Login = login;
            Email = email;
            Address = address;
            Material = material;
        }

        public Login Login { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public Material Material { get; private set; }

        public List<Spaceship>? Spaceships { get; private set; }
    }
}
