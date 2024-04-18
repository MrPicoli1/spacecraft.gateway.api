using Spaceship.Gateway.Models.User;
using Spaceship.Gateway.Models.ValueObjects;

namespace Spaceship.Gateway.Models.Spaceship
{
    public class SpaceshipModel
    {

        public SpaceshipModel() { }

      

        public StatusModel Status { get;  set; }
        public MaterialModel BaseRankUpMaterial { get;  set; }
        public bool Idle { get; set; }
        public DateTime? MissionEnd { get;  set; }

        public Guid? UserId { get;  set; }
    }
}
