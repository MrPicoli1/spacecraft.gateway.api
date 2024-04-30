using AutoMapper;
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
        private readonly IMapper _mapper;

        public MissionService(HttpClientExtensions httpClientExtensions,
            IOptions<SpaceshipMongoDbSettings> settings,
            SpaceshipMySQLContext mySQLContext,
            IMessageProducer messageProducer,
            IMapper mapper)
        {
            _httpClientExtensions = httpClientExtensions;


            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _missionCollection = database.GetCollection<Mission>(settings.Value.CollectionName);
            _mySQLContext = mySQLContext;
            _messageProducer = messageProducer;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MissionModel>> CreateMissionsAsync()
        {
            var url = "https://localhost:7130/";
            return await _httpClientExtensions.GetList<MissionModel>(url);

        }

        public async Task<Spaceships> StartMission(MissionModel model)
        {


            var mission =_mapper.Map<Mission>(model);

            var spaceship =await _mySQLContext.Spaceships.FirstOrDefaultAsync(x => x.Id == model.SpaceshipId);
            spaceship.SendOnMission(mission);
           
            _messageProducer.SendMessage(mission);


            _mySQLContext.Spaceships.Update(spaceship);
            await _mySQLContext.SaveChangesAsync();
            await _missionCollection.InsertOneAsync(mission);

            return spaceship;
            
            
           
        }

        public async Task<bool> EndMission(Guid missionId)
        {
            var mission = await _missionCollection.Find(x => x.Id == missionId).FirstOrDefaultAsync();

            if(mission == null)
            {
                return false;
            }

            var spaceship = await _mySQLContext.Spaceships.FirstOrDefaultAsync(x => x.Id == mission.SpaceshipId);
            var user = await _mySQLContext.Users.FirstOrDefaultAsync(x => x.Id == spaceship.UserId);

            var fail = mission.FailChance(spaceship.Status);
            spaceship.ReturnFromMission();
            if (fail)
            {
                var damage = (spaceship.Status.CurrentHP / 2);
                spaceship.TakeDamage(damage);
                _mySQLContext.Spaceships.Update(spaceship);
                await _mySQLContext.SaveChangesAsync();
                return true;
            }
            

            spaceship.TakeDamage(mission.DamadgeTaken(spaceship.Status));
            user.AddMaterial(mission.Reward());

            

            _mySQLContext.Spaceships.Update(spaceship);
            _mySQLContext.Users.Update(user);
            await _mySQLContext.SaveChangesAsync();

            return true;
        }
       

        public async Task<List<Mission>> GetSpaceshipMissionsAsync(Guid spaceshipId)
        {
            return await _missionCollection.Find(x => x.SpaceshipId == spaceshipId).ToListAsync();
        }

    }
}
