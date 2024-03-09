namespace Spaceship.CreateSpaceship.API.Domain.ValeuObjects
{
    public class StatusModel
    {
        private Random random = new Random();
        public StatusModel(int rank)
        {

            TotalHP = random.Next(20*rank,40*rank);
            CurrentHP = TotalHP;
            RepairCost = 0;
            Damage = random.Next(5*rank,15*rank);
            Rank = rank;
            Tier = 0;
        }

        public int TotalHP { get; set; }
        public int CurrentHP { get; set; }
        public int RepairCost { get; set; }
        public int Damage { get; set; }
        public int Rank { get; set; }
        public int Tier { get; set; }
    }
}
