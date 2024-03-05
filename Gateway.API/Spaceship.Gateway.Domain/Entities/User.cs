using Spaceship.Gateway.Domain.ValueObjects;
using Spaceship.Gateway.Shared.Entities;
using System.Xml.Linq;

namespace Spaceship.Gateway.Domain.Entities
{
    public class User : Entity
    {
        public User(Login login,
            Email email,
            Address address,
            Material material,
            Name name)
        {
            Login = login;
            Email = email;
            Address = address;
            Material = material;
            Name = name;

            AddNotifications(name, email, login);
            
        }

        public Name Name { get; private set; }
        public Login Login { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public Material Material { get; private set; }
        

        public List<Spaceships>? Spaceships { get; set; }

    }
}
