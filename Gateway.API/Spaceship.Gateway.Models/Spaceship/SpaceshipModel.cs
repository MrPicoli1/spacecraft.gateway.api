using Spaceship.Gateway.Models.User;
using Spaceship.Gateway.Models.ValueObjects;

namespace Spaceship.Gateway.Models.Spaceship
{
    public class SpaceshipModel
    {
        public SpaceshipModel(StatusModel status,
                        bool idle,
                        Guid userId,
                        UserModel user,
                        MaterialModel baseRankUpMaterial)
        {
            Idle = idle;
            UserId = userId;
            User = user;
            Status = status;
            BaseRankUpMaterial = baseRankUpMaterial;
        }

        public StatusModel Status { get;  set; }
        public MaterialModel BaseRankUpMaterial { get;  set; }
        public bool Idle { get; private set; }
        public DateTime? MissionEnd { get;  set; }

        public Guid UserId { get;  set; }

        public UserModel User { get;  set; }
    }
}
