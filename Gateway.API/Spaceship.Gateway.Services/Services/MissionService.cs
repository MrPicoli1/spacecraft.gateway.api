using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Spaceship.Gateway.Data.RabbitMq;
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
        private readonly SpaceshipMySQLContext _mySQLContext;
        private readonly IMessageProducer _messageProducer;

        public MissionService(HttpClientExtensions httpClientExtensions,
            IOptions<SpaceshipMongoDbSettings> settings,
            SpaceshipMySQLContext mySQLContext,
            IMessageProducer messageProducer)
        {
            _httpClientExtensions = httpClientExtensions;
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _missionCollection = database.GetCollection<Mission>(settings.Value.CollectionName);
            _mySQLContext = mySQLContext;
            _messageProducer = messageProducer;
        }

        public async Task<List<MissionModel>> CreateMissionsAsync()
        {
            var url = "https://localhost:7414/";
            return await _httpClientExtensions.GetList<MissionModel>(url);

        }

        public async Task<Spaceships> StartMission(Guid spaceshipId, Mission mission)
        {
            var spaceship =await _mySQLContext.Spaceships.FirstOrDefaultAsync(x => x.Id == spaceshipId);
            spaceship.SendOnMission(mission);
            _mySQLContext.Spaceships.Update(spaceship);
            await _mySQLContext.SaveChangesAsync();
            _messageProducer.SendMessage(mission);  

            await _missionCollection.InsertOneAsync(mission);

            return spaceship;
            
            
           
        }

        public async Task EndMission(Guid missionId)
        {
            var mission = await _missionCollection.Find(x => x.Id == missionId).FirstOrDefaultAsync();
            // fazer a logica de finalizar a missao
        }
       

        public async Task<List<Mission>> GetSpaceshipMissionsAsync(Guid spaceshipId)
        {
            return await _missionCollection.Find(x => x.SpaceshipId == spaceshipId).ToListAsync();
        }

    }
}
