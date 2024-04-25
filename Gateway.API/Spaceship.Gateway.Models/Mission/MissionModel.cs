
using Spaceship.Gateway.Models.ValueObjects;

namespace Spaceship.Gateway.Models.Mission
{
    public class MissionModel
    {

        public MissionModel(MaterialModel maxMaterial, MaterialModel minMaterial, DifficultyModel difficulty)
        {
            MaxMaterial = maxMaterial;
            MinMaterial = minMaterial;
            Difficulty = difficulty;
           

        }

        public MaterialModel MaxMaterial { get;  set; }
        public MaterialModel MinMaterial { get;  set; }
        public DifficultyModel Difficulty { get;  set; }
        public DateTime? EndMission { get;  set; }
        public Guid? SpaceshipId { get;  set; }



    }
}
