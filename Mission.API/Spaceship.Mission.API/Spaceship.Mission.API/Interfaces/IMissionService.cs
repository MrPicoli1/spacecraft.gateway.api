using Spaceship.Mission.API.Domain.Entities;

namespace Spaceship.Mission.API.Interfaces
{
    public interface IMissionService
    {
        public List<MissionModel> CreateMission();

    }
}
