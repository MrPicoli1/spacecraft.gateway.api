using Spaceship.Gateway.Domain.Entities;
using Spaceship.Gateway.Models.Mission;

namespace Spaceship.Gateway.Services.Interfaces
{
    public interface IMissionService
    {
        public Task<IEnumerable<MissionModel>> CreateMissionsAsync();
        Task<Spaceships> StartMission(MissionModel model);
        public Task<List<Mission>> GetSpaceshipMissionsAsync(Guid spaceshipId);
        public Task<bool> EndMission(Guid missionId);
    }
}
