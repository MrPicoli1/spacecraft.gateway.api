using Spaceship.Mission.API.Domain.Entities;
using Spaceship.Mission.API.Interfaces;

namespace Spaceship.Mission.API.Services
{
    public class MissionService : IMissionService
    {
        public List<MissionModel> CreateMission()
        {
            var missionList = new List<MissionModel>
            {
                new MissionModel(1),
                new MissionModel(2),
                new MissionModel(3)
            };
            return missionList;

        }
    }
}
