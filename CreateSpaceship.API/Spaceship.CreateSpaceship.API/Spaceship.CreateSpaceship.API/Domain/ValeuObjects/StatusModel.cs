namespace Spaceship.CreateSpaceship.API.Domain.ValeuObjects
{
    public class StatusModel
    {
        private Random random = new Random();
        public StatusModel(int tier)
        {

            TotalHP = random.Next(20* tier, 40* tier);
            CurrentHP = TotalHP;
            RepairCost = 0;
            Damage = random.Next(5* tier, 15* tier);
            Rank = 0;
            Tier = tier;
        }

        public int TotalHP { get; set; }
        public int CurrentHP { get; set; }
        public int RepairCost { get; set; }
        public int Damage { get; set; }
        public int Rank { get; set; }
        public int Tier { get; set; }
    }
}
