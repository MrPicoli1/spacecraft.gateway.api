using Spaceship.Gateway.Shared.ValueObject;

namespace Spaceship.Gateway.Domain.ValueObjects
{
    public class Status : ValueObject
    {
        public Status(int totalHP, int currentHP, int damage, int rank, int tier)
        {
            TotalHP = totalHP;
            CurrentHP = currentHP;
            Damage = damage;
            Rank = rank;
            Tier = tier;

            RepairCost = 10 * (Tier) + (Rank * (15 / 100)) + TotalHP / CurrentHP;
            

        }

        public int TotalHP { get; private set; }
        public int CurrentHP { get; private set; }
        public int RepairCost { get; private set; }
        public int Damage { get; private set; }
        public int Rank { get; private set; }
        public int Tier { get; private set; }

        public void Repair()
        {
            CurrentHP = TotalHP;
        }

    }
}
