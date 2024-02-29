using Spaceship.Gateway.Shared.ValueObject;

namespace Spaceship.Gateway.Models.ValueObjects
{
    public class MaterialModel: ValueObject
    {
        public int Metal { get;  set; }
        public int Crystal { get;  set; }
        public int Currency { get;  set; }
    }
}
