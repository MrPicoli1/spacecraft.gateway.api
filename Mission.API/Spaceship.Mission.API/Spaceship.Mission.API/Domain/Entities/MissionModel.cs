using Spaceship.Mission.API.Domain.ValueObjects;

namespace Spaceship.Mission.API.Domain.Entities
{
    public class MissionModel
    {
        private Random random = new Random();
        public MissionModel(int difficulty)
        {
            Difficulty = new DifficultyModel(difficulty);
            MinMaterial = new MaterialModel(random.Next(difficulty, difficulty * Difficulty.MissionRank));
            MaxMaterial = new MaterialModel(random.Next(5*difficulty, 5*(difficulty * Difficulty.MissionRank)));
            EndMission = DateTime.Now.AddHours(difficulty).AddMinutes(Difficulty.MissionRank*10);
        }

        public MaterialModel MinMaterial { get; set; }
        public MaterialModel MaxMaterial { get; set; }
        public DifficultyModel Difficulty { get; set; }
        public DateTime EndMission { get; private set; }
    }
}
