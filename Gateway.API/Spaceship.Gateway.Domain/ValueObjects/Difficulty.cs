namespace Spaceship.Gateway.Domain.ValueObjects
{
    public class Difficulty
    {
        public Difficulty(int dificultLevel, int missionRank, decimal baseFailChance)
        {
            DificultLevel = dificultLevel;
            MissionRank = missionRank;
            BaseFailChance = baseFailChance;
        }

        public int DificultLevel { get; private set; }
        public int MissionRank { get; private set; }
        public decimal BaseFailChance { get; private set; }
    }
}
