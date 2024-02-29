using Spaceship.Gateway.Domain.ValueObjects;
using Spaceship.Gateway.Shared.Entities;

namespace Spaceship.Gateway.Domain.Entities
{
    public class Mission : Entity
    {
        public Mission(Material maxMaterial,
            Material minMaterial,
            Difficulty difficulty, 
            Guid spaceshipId,
            Spaceships spaceship)
        {
            MaxMaterial = maxMaterial;
            MinMaterial = minMaterial;
            Difficulty = difficulty;
            SpaceshipId = spaceshipId;
            Spaceship = spaceship;
        }

        public Material MaxMaterial { get; private set; }
        public Material MinMaterial { get; private set; }
        public Difficulty Difficulty { get; private set; }

        public Guid SpaceshipId { get; private set; }
        public Spaceships Spaceship { get; private set; }


    }
}
