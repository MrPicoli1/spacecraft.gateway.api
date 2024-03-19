using Spaceship.Gateway.Models.User;
using Spaceship.Gateway.Models.ValueObjects;

namespace Spaceship.Gateway.Models.Spaceship
{
    public class SpaceshipModel
    {
        public SpaceshipModel(StatusModel status,
                        bool idle,
                        MaterialModel baseRankUpMaterial)
        {
            Idle = idle;
            Status = status;
            BaseRankUpMaterial = baseRankUpMaterial;
        }

        public SpaceshipModel(StatusModel status, MaterialModel baseRankUpMaterial, bool idle, DateTime? missionEnd, Guid? userId, UserModel? user)
        {
            Status = status;
            BaseRankUpMaterial = baseRankUpMaterial;
            Idle = idle;
            MissionEnd = missionEnd;
            UserId = userId;
            User = user;
        }

        public StatusModel Status { get;  set; }
        public MaterialModel BaseRankUpMaterial { get;  set; }
        public bool Idle { get; private set; }
        public DateTime? MissionEnd { get;  set; }

        public Guid? UserId { get;  set; }

        public UserModel? User { get;  set; }
    }
}
