using Spaceship.Gateway.Domain.Entities;
using Spaceship.Gateway.Models.Spaceship;

namespace Spaceship.Gateway.Services.Interfaces
{
    public interface ISpaceshipService
    {
        Task<List<SpaceshipModel>> GetNewSpaceshipsAsync();
        Task<List<Spaceships>> GetAllSpaceshipsAsync(Guid userId);
        Task<Spaceships> PostSpaceAsync(SpaceshipModel model);
        Task<Spaceships> Repair(Guid spaceshipId);
        Task<Spaceships> RankUp(Guid spaceshipId);
        Task<bool> DeleteSpaceshipAsync(Guid spaceshipId);
    }
}
