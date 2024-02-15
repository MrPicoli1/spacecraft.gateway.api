using Spaceship.Gateway.Domain.ValueObjects;
using Spaceship.Gateway.Shared.Entities;

namespace Spaceship.Gateway.Domain.Entities
{
    public class Spaceship : Entity
    {
        public Spaceship(HitPoints hitPoints, int damage, int rank, bool idle, Guid userId, User user)
        {
            HitPoints = hitPoints;
            Damage = damage;
            Rank = rank;
            Idle = idle;
            UserId = userId;
            User = user;
        }

        public HitPoints HitPoints { get; private set; }
        public int Damage { get; private set; }
        public int Rank { get; private set; }
        public bool Idle { get; private set; }

        public Guid UserId { get; private set; }

        public User User { get; private set; }

    }
}
