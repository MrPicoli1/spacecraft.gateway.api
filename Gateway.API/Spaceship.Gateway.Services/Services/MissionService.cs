using Spaceship.Gateway.Domain.Entities;
using Spaceship.Gateway.Extensions.Http;
using Spaceship.Gateway.Models.Mission;
using Spaceship.Gateway.Services.Interfaces;
using System.Reflection.Metadata;

namespace Spaceship.Gateway.Services.Services
{
    public class MissionService : IMissionService
    {
        private readonly HttpClientExtensions _httpClientExtensions;

        public MissionService(HttpClientExtensions httpClientExtensions)
        {
            _httpClientExtensions = httpClientExtensions;
        }

        public async Task<List<MissionModel>> CreateMissionsAsync()
        {
            var url = "https://localhost:7414/";
            return await _httpClientExtensions.GetList<MissionModel>(url);

        }

        public Task EndMission(Guid missionId)
        {
            throw new NotImplementedException();
        }

        public Task<Mission> GetSpaceshipMissionsAsync(Guid spaceshipId)
        {
            throw new NotImplementedException();
        }
    }
}
