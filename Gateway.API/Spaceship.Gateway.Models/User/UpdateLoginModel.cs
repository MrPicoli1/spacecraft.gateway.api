using Spaceship.Gateway.Models.ValueObjects;

namespace Spaceship.Gateway.Models.User
{
    public class UpdateLoginModel
    {
        public UpdateLoginModel(Guid id, LoginModel login)
        {
            Id = id;
            Login = login;
        }

        public Guid Id { get; set; }
        public LoginModel Login { get; set; }
      
    }
}
