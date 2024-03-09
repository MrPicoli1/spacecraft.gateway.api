namespace Spaceship.CreateSpaceship.API.Domain.ValeuObjects
{
    public class MaterialModel
    {
        private Random random = new Random();
        public MaterialModel(int rank)
        {
            Metal = random.Next(15*rank,30*rank);
            Crystal = random.Next(5 * rank, 10 * rank);
            Currency = random.Next(50 * rank, 100 * rank);
        }

        public int Metal { get; set; }
        public int Crystal { get; set; }
        public int Currency { get; set; }
    }
}
