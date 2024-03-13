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

            if (totalHP == currentHP)
            {
                RepairCost = 0;
            }
            else
            {
                RepairCost = 10 * (Tier) + (Rank * (15 / 100)) + TotalHP / CurrentHP;
            }

            
            

        }

        public int TotalHP { get; private set; }
        public int CurrentHP { get; private set; }
        public int RepairCost { get; private set; }
        public int Damage { get; private set; }
        public int Rank { get; private set; }
        public int Tier { get; private set; }

        public void Repair(int porcentage)
        {
            CurrentHP = (porcentage/100)*TotalHP;
        }

        public void TakeDamadge(int amount)
        {
            if (amount > CurrentHP)
            {
                CurrentHP = 0;
            }
            else
            {
                CurrentHP -= amount;
            }
        }
        public void RankUp()
        {
            Rank += 1;
        }

    }
}
