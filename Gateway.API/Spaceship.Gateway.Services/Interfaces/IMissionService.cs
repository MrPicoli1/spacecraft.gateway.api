using Spaceship.Gateway.Domain.Entities;
using Spaceship.Gateway.Models.Mission;

namespace Spaceship.Gateway.Services.Interfaces
{
    public interface IMissionService
    {
        public Task<List<MissionModel>> CreateMissionsAsync();
        public Task<Mission> GetSpaceshipMissionsAsync(Guid spaceshipId);
        public Task EndMission(Guid missionId);
    }
}
