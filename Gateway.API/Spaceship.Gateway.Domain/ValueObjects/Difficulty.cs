using Spaceship.Gateway.Shared.ValueObject;

namespace Spaceship.Gateway.Domain.ValueObjects
{
    public class Difficulty: ValueObject
    {
        public Difficulty(int dificultLevel, int missionRank, int baseFailChance)
        {
            DificultLevel = dificultLevel;
            MissionRank = missionRank;
            BaseFailChance = baseFailChance;
        }

        public int DificultLevel { get; private set; }
        public int MissionRank { get; private set; }
        public int BaseFailChance { get; private set; }
    }
}
