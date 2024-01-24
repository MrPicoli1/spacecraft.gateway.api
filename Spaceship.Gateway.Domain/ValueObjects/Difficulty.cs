namespace Spaceship.Gateway.Domain.ValueObjects
{
    public class Difficulty
    {
        public Difficulty(int dificultLevel, int missionRank)
        {
            DificultLevel = dificultLevel;
            MissionRank = missionRank;
        }

        public int DificultLevel { get; private set; }
        public int MissionRank { get; private set; }
    }
}
