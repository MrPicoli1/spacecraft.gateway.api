using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Spaceship.Gateway.Data.Repositories;
using Spaceship.Gateway.Domain.Entities;
using Spaceship.Gateway.Extensions.Http;
using Spaceship.Gateway.Models.Mission;
using Spaceship.Gateway.Services.Interfaces;


namespace Spaceship.Gateway.Services.Services
{
    public class MissionService : IMissionService
    {
        private readonly HttpClientExtensions _httpClientExtensions;
        private readonly IMongoCollection<Mission> _missionCollection;


        public MissionService(HttpClientExtensions httpClientExtensions, IOptions<SpaceshipMongoDbSettings> settings)
        {
            _httpClientExtensions = httpClientExtensions;
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _missionCollection = database.GetCollection<Mission>(settings.Value.CollectionName);
        }

        public async Task<List<MissionModel>> CreateMissionsAsync()
        {
            var url = "https://localhost:7414/";
            return await _httpClientExtensions.GetList<MissionModel>(url);

        }

        public Task<Spaceships> StartMission(Guid spaceshipId, Mission mission)
        {
            throw new NotImplementedException();
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
