namespace Spaceship.Mission.API.Domain.ValueObjects
{
    public class DifficultyModel
    {
        private Random random = new Random();
        public DifficultyModel(int dificultLevel)
        {
            DificultLevel = dificultLevel;
            MissionRank = random.Next(1,5);

           switch (dificultLevel) 
            {
                case 1:
                    BaseFailChance = random.Next(10,30); 
                    break;
                case 2:
                    BaseFailChance = random.Next(20, 40);
                    break;
                case 3:
                    BaseFailChance = random.Next(30, 60);
                    break;
            }

            

          
        }

        public int DificultLevel { get; set; }
        public int MissionRank { get; set; }
        public int BaseFailChance { get; set; }
    }
}
