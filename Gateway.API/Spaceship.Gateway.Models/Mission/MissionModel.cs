using Spaceship.Gateway.Models.Spaceship;
using Spaceship.Gateway.Models.ValueObjects;

namespace Spaceship.Gateway.Models.Mission
{
    public class MissionModel
    {
        public MissionModel(MaterialModel maxMaterial, MaterialModel minMaterial, DifficultyModel difficulty,
          Guid spaceshipId, SpaceshipModel spaceship)
        {
            MaxMaterial = maxMaterial;
            MinMaterial = minMaterial;
            Difficulty = difficulty;
            SpaceshipId = spaceshipId;
            Spaceship = spaceship;
        }

        public MaterialModel MaxMaterial { get;  set; }
        public MaterialModel MinMaterial { get;  set; }
        public DifficultyModel Difficulty { get;  set; }

        public Guid SpaceshipId { get;  set; }
        public SpaceshipModel Spaceship { get;  set; }



    }
}
