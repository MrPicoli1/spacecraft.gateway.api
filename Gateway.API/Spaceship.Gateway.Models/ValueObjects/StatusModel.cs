using Spaceship.Gateway.Shared.ValueObject;

namespace Spaceship.Gateway.Models.ValueObjects
{
    public class StatusModel : ValueObject
    {
        public StatusModel(int totalHP, int currentHP, int repairCost, int damage, int rank, int tier)
        {
            TotalHP = totalHP;
            CurrentHP = currentHP;
            RepairCost = repairCost;
            Damage = damage;
            Rank = rank;
            Tier = tier;
        }

        public int TotalHP { get;  set; }
        public int CurrentHP { get;  set; }
        public int RepairCost { get;  set; }
        public int Damage { get;  set; }
        public int Rank { get;  set; }
        public int Tier { get;  set; }
    }
}
