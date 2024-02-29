namespace Spaceship.Gateway.Models.ValueObjects
{
    public class DifficultyModel
    {
        public DifficultyModel(int dificultLevel, int missionRank, int baseFailChance)
        {
            DificultLevel = dificultLevel;
            MissionRank = missionRank;
            BaseFailChance = baseFailChance;
        }

        public int DificultLevel { get;  set; }
        public int MissionRank { get;  set; }
        public int BaseFailChance { get;  set; }
    }
}
