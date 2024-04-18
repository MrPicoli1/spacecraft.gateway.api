using Spaceship.Gateway.Models.ValueObjects;


namespace Spaceship.Gateway.Models.User
{
    public class UserModel
    {
        public UserModel()
        {
            Material = new MaterialModel(0,0,0);
        }

        public LoginModel? Login { get; set; }
        public EmailModel? Email { get; set; }
        public AddressModel? Address { get; set; }
        public MaterialModel? Material { get; private set; }
        public NameModel? Name { get; set; }
    }
}
