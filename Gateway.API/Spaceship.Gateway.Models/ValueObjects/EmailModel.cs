using Spaceship.Gateway.Shared.ValueObject;

namespace Spaceship.Gateway.Models.ValueObjects
{
    public class EmailModel : ValueObject
    {
        public EmailModel(string address)
        {
            Address = address;
        }

        public string Address { get;  set; }
    }
}
