using Microsoft.AspNetCore.Http;
using Spaceship.CreateSpaceship.API.Domain.ValeuObjects;

namespace Spaceship.CreateSpaceship.API.Domain.Entities
{
    public class SpaceshipModel
    {
        public SpaceshipModel(int rank)
        {
            Idle = true;
            Status = new StatusModel(rank);
            BaseRankUpMaterial = new MaterialModel(rank);
        }

        public StatusModel Status { get; set; }
        public MaterialModel BaseRankUpMaterial { get; set; }
        public bool Idle { get; private set; }
        public DateTime? MissionEnd { get; set; }

    }
}

