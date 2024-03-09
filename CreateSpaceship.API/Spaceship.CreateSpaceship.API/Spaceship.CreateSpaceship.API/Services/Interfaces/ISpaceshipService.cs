using Spaceship.CreateSpaceship.API.Domain.Entities;

namespace Spaceship.CreateSpaceship.API.Services.Interfaces
{
    public interface ISpaceshipService
    {
        List<SpaceshipModel> CreateSpaceships();  
    }
}
