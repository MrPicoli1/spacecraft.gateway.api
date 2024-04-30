using Spaceship.Gateway.Domain.ValueObjects;
using Spaceship.Gateway.Shared.Entities;
using System.ComponentModel.DataAnnotations.Schema;

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
        [NotMapped]
        private Random random = new Random();

        public Material MaxMaterial { get; private set; }
        public Material MinMaterial { get; private set; }
        public Difficulty Difficulty { get; private set; }
        public DateTime EndMission {  get; private set; }
        public Guid SpaceshipId { get; private set; }
        

        public bool FailChance(Status status)
        {
           var fail = random.Next(0, 100);
            if (fail < (Difficulty.BaseFailChance-(status.Rank*status.Tier)))
            {
                return true;
            }
            return false;
        }

        public int DamadgeTaken(Status status)
        {
            
            return random.Next(0, (2*Difficulty.DificultLevel)+Difficulty.MissionRank);
            
        }

        public Material Reward()
        {
            return new Material(random.Next(MinMaterial.Crystal, MaxMaterial.Crystal),
                                               random.Next(MinMaterial.Metal, MaxMaterial.Metal),
                                                                              random.Next(MinMaterial.Currency, MaxMaterial.Currency));
        }

    }
}
