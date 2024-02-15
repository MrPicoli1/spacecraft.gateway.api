using Spaceship.Gateway.Shared.ValueObject;

namespace Spaceship.Gateway.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string Address { get; private set; }
    }
}
