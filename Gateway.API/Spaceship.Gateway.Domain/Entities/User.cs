using Spaceship.Gateway.Domain.ValueObjects;
using Spaceship.Gateway.Shared.Entities;

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
        }

        private User() { }

        public Name Name { get; private set; }
        public Login Login { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public Material Material { get; private set; }
        

        public List<Spaceships>? Spaceships { get; set; }



        public void UpdateInfo(User user)
        {
            Name = user.Name;
            Address = user.Address;
            Updated();
        }
        public void UpdateLogin(Login login)
        {
            Login = login;
            Updated();
        }
        public void AddMaterial(Material material)
        {
            Material.AddMaterial(material.Currency,material.Crystal,material.Metal);
            Updated();
        }
        public void RepairSpaceship() { }
        public void RankUpSpaceship() { }

    }
}
