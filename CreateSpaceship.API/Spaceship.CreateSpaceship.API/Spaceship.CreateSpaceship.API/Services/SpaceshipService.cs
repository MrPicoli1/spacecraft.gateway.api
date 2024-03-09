using Spaceship.CreateSpaceship.API.Domain.Entities;
using Spaceship.CreateSpaceship.API.Services.Interfaces;

namespace Spaceship.CreateSpaceship.API.Services
{
    public class SpaceshipService : ISpaceshipService
    {
        public List<SpaceshipModel> CreateSpaceships()
        {
            var list = new List<SpaceshipModel>();
            list.Add(new SpaceshipModel(1));
            list.Add(new SpaceshipModel(2));
            list.Add(new SpaceshipModel(3));

            return list;
        }
    }
}
