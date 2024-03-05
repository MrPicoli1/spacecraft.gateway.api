using Flunt.Validations;
using Spaceship.Gateway.Shared.ValueObject;


namespace Spaceship.Gateway.Domain.ValueObjects
{
    public class Email : ValueObject
    {

        public Email(string address)
        {
            Address = address;

            AddNotifications(new Contract<Email>().Requires().IsEmailOrEmpty(Address, "Email Invalodo").IsEmail(address, "Email Invalido"));
        }

        public string Address { get; private set; }


    }
}
