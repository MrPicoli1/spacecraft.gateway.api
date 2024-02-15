using Spaceship.Gateway.Domain.ValueObjects;
using Spaceship.Gateway.Shared.Entities;

namespace Spaceship.Gateway.Domain.Entities
{
    public class Spaceship : Entity
    {
        public Spaceship(Status status,
                         bool idle,
                         Guid userId,
                         User user,
                         Material baseRankUpMaterial)
        {
            Idle = idle;
            UserId = userId;
            User = user;
            Status = status;
            BaseRankUpMaterial = baseRankUpMaterial;
        }

        public Status Status { get; private set; }
        public Material BaseRankUpMaterial { get; private set; }
        public bool Idle { get; private set; }
        public DateTime? MissionEnd { get; private set; }

        public Guid UserId { get; private set; }

        public User User { get; private set; }

    }
}
