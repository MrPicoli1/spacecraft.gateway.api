using Spaceship.Gateway.Domain.ValueObjects;
using Spaceship.Gateway.Shared.Entities;

namespace Spaceship.Gateway.Domain.Entities
{
    public class Mission : Entity
    {
        public Mission(Material maxMaterial,
            Material minMaterial,
            Difficulty difficulty, 
            Guid spaceshipId)
        {
            MaxMaterial = maxMaterial;
            MinMaterial = minMaterial;
            Difficulty = difficulty;
            SpaceshipId = spaceshipId;
        }

        public Material MaxMaterial { get; private set; }
        public Material MinMaterial { get; private set; }
        public Difficulty Difficulty { get; private set; }
        public DateTime EndMission {  get; private set; }

        public Guid SpaceshipId { get; private set; }
        


    }
}
