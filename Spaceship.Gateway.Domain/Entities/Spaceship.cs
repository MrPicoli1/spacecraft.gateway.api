using Spaceship.Gateway.Domain.ValueObjects;
using Spaceship.Gateway.Shared.Entities;

namespace Spaceship.Gateway.Domain.Entities
{
    public class Spaceship : Entity
    {
        public Spaceship(string name, HitPoints hitPoints, int damage, int rank)
        {
            Name = name;
            HitPoints = hitPoints;
            Damage = damage;
            Rank = rank;
        }

        public string Name { get; private set; }
        public HitPoints HitPoints { get; private set; }
        public int Damage { get; private set; }
        public int Rank { get; private set; }

    }
}
