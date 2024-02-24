using Spaceship.Gateway.Domain.ValueObjects;


namespace Spaceship.Gateway.Models.User
{
    public class UserModel
    {
        public UserModel(Login login, Email email, Address address, Material material)
        {
            Login = login;
            Email = email;
            Address = address;
            Material = material;
        }

        public Login Login { get; set; }
        public Email Email { get; set; }
        public Address Address { get; set; }
        public Material Material { get; set; }
    }
}
