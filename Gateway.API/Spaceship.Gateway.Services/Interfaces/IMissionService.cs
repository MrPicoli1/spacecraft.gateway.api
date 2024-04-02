using Spaceship.Gateway.Domain.Entities;
using Spaceship.Gateway.Models.Mission;

namespace Spaceship.Gateway.Services.Interfaces
{
    public interface IMissionService
    {
        public Task<List<MissionModel>> CreateMissionsAsync();
        Task<Spaceships> StartMission(Guid spaceshipId, Mission mission);
        public Task<List<Mission>> GetSpaceshipMissionsAsync(Guid spaceshipId);
        public Task EndMission(Guid missionId);
    }
}
