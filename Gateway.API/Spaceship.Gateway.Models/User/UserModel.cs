using Spaceship.Gateway.Models.ValueObjects;


namespace Spaceship.Gateway.Models.User
{
    public class UserModel
    {
        public UserModel(LoginModel login, EmailModel email, AddressModel address, MaterialModel material)
        {
            Login = login;
            Email = email;
            Address = address;
            Material = material;
        }

        public LoginModel Login { get; set; }
        public EmailModel Email { get; set; }
        public AddressModel Address { get; set; }
        public MaterialModel Material { get; set; }
    }
}
