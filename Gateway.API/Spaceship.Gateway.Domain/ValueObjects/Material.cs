using Spaceship.Gateway.Shared.ValueObject;

namespace Spaceship.Gateway.Domain.ValueObjects
{
    public class Material: ValueObject
    {
        public int Metal { get; private set; }
        public int Crystal { get; private set; }
        public int Currency { get; private set; }
    }
}
