using Spaceship.Gateway.Shared.ValueObject;

namespace Spaceship.Gateway.Domain.ValueObjects
{
    public class Status : ValueObject
    {
        public Status(int totalHP, int currentHP, int repairCost, int damage, int rank, int tier)
        {
            TotalHP = totalHP;
            CurrentHP = currentHP;
            RepairCost = repairCost;
            Damage = damage;
            Rank = rank;
            Tier = tier;
        }

        public int TotalHP { get; private set; }
        public int CurrentHP { get; private set; }
        public int RepairCost { get; private set; }
        public int Damage { get; private set; }
        public int Rank { get; private set; }
        public int Tier { get; private set; }
    }
}
