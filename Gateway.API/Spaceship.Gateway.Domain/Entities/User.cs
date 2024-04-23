using Spaceship.Gateway.Domain.ValueObjects;
using Spaceship.Gateway.Models.User;
using Spaceship.Gateway.Shared.Entities;
using System.ComponentModel.DataAnnotations.Schema;


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
            IsValid();
        }

#pragma warning disable CS8618 
        private User() { }
#pragma warning restore CS8618 

        public Name Name { get; private set; }
        public Login Login { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public Material Material { get; private set; }
        

        public List<Spaceships>? Spaceships { get; set; }
        [NotMapped]
        public List<string> Notifications { get; private set; } = new List<string>();


        public void UpdateInfo(Name name , Address address)
        {
            Name = name;
            Address = address;
            IsValid();
            Updated();
        }
        public void UpdateLogin(Login login)
        {
            Login = login;
            IsValid();
            Updated();
        }
        public void AddMaterial(Material material)
        {
            Material.AddMaterial(material.Currency,material.Crystal,material.Metal);
            Updated();
        }
        public int RepairSpaceship(int cost) 
        {
            if (Material.Currency == 0)
            {
                AddNotification("Currency", "You don't have enough currency to repair the spaceship");
                return 0;
            }
            if(Material.Currency < cost)
            {
                int total =cost - (cost - Material.Currency);

                Material.RemoveMaterial(Material.Currency, 0,0);

                return total;
            }
                Material.RemoveMaterial(cost, 0, 0);
            Updated();
                return cost;
        }
        public void RankUpSpaceship(Material material) 
        {
            if(Material.Currency < material.Currency || Material.Crystal < material.Crystal || Material.Metal < material.Metal)
            {
                AddNotification("Material", "You don't have enough material to rank up the spaceship");
                return;
            }
            Material.RemoveMaterial(material.Currency, material.Crystal, material.Metal);
            Updated();
        }

        public void AddNotification(string key, string message)
        {
            Notifications.Add(key + " - " + message);
        }


        public void IsValid()
        {
            if(Name.FirstName.Length<=2)
                AddNotification("FirstName", "Name must be at least 2 characters");
            if(Name.LastName.Length<=2)
                AddNotification("LastName", "Name must be at least 2 characters");
            if(Login.Username.Length<=3)
                AddNotification("Login", "Login must be at least 3 characters");
            if(!Email.IsValid())
                AddNotification("Email", "Email invalid");
            if(Address.Street.Length<=3)
                AddNotification("Address", "Address must be at least 3 characters");
            if (Login.Password.Length <= 6)
                AddNotification("Password", "Password must be at least 6 characters");

        }

    }
}
