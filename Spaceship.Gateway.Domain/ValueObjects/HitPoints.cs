using Spaceship.Gateway.Shared.ValueObject;

namespace Spaceship.Gateway.Domain.ValueObjects
{
    public class HitPoints : ValueObject
    {
        public int TotalHP { get; private set; }
        public int CurrentHP { get; private set; }
        public int RepairCost { get; private set; }
    }
}
