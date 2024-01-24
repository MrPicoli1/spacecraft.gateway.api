using Spaceship.Gateway.Domain.ValueObjects;
using Spaceship.Gateway.Shared.Entities;

namespace Spaceship.Gateway.Domain.Entities
{
    public class Mission : Entity
    {
        public Mission(string name, Material maxMaterial, Material minMaterial, Difficulty difficulty)
        {
            Name = name;
            MaxMaterial = maxMaterial;
            MinMaterial = minMaterial;
            Difficulty = difficulty;
        }

        public string Name { get; private set; }
        public Material MaxMaterial { get; private set; }
        public Material MinMaterial { get; private set; }
        public Difficulty Difficulty { get; private set; }


    }
}
