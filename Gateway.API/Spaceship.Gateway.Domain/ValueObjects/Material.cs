using Spaceship.Gateway.Shared.ValueObject;

namespace Spaceship.Gateway.Domain.ValueObjects
{
    public class Material: ValueObject
    {
        public Material(int metal, int crystal, int currency)
        {
            Metal = metal;
            Crystal = crystal;
            Currency = currency;
        }

        public int Metal { get; private set; }
        public int Crystal { get; private set; }
        public int Currency { get; private set; }


        public void AddMaterial(int currency, int crystal, int metal)
        {
            Crystal += crystal;
            Metal += metal;
            Currency += currency;
        }

    }
}
