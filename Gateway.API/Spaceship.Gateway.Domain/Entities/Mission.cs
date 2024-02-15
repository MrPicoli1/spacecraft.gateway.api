using Spaceship.Gateway.Domain.ValueObjects;
using Spaceship.Gateway.Shared.Entities;

namespace Spaceship.Gateway.Domain.Entities
{
    public class Mission : Entity
    {
        public Mission(string name, Material maxMaterial, Material minMaterial, Difficulty difficulty, 
            Guid spaceshipId, Spaceship spaceship)
        {
            Name = name;
            MaxMaterial = maxMaterial;
            MinMaterial = minMaterial;
            Difficulty = difficulty;
            SpaceshipId = spaceshipId;
            Spaceship = spaceship;
        }

        public string Name { get; private set; }
        public Material MaxMaterial { get; private set; }
        public Material MinMaterial { get; private set; }
        public Difficulty Difficulty { get; private set; }

        public Guid SpaceshipId { get; private set; }
        public Spaceship Spaceship { get; private set; }


    }
}
