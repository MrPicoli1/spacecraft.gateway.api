using AutoMapper;
using Spaceship.Gateway.Domain.Entities;
using Spaceship.Gateway.Models.Spaceship;
using Spaceship.Gateway.Services.Interfaces;
using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;

namespace Spaceship.Gateway.Services.Services
{
    public class SpaceshipService : ISpaceshipService
    {
        private List<Spaceships> _spaceships;
        private readonly IMapper _mapper;

        public SpaceshipService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<bool> DeleteSpaceshipAsync(Guid spaceshipId)
        {
            var exists = _spaceships.FirstOrDefault(x => x.Id == spaceshipId);

            if (exists != null)
            {
                return false;
            }


            _spaceships.FirstOrDefault(x => x.Id == spaceshipId).Delete();


            return true;
        }

        public async Task<List<Spaceships>> GetAllSpaceshipsAsync(Guid userId)
        {
           return _spaceships.FindAll(x => x.UserId == userId);
        }

        public async Task<List<SpaceshipModel>> GetNewSpaceshipsAsync()
        {
            HttpClient httpClient = new HttpClient();

            var url = "https://localhost:7414/";

            //var json = JsonSerializer.Serialize(model);
            // var data = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.GetAsync(url);
            if (responseMessage != null)
            {
                return await responseMessage.Content.ReadFromJsonAsync<List<SpaceshipModel>>();
            }

            return null;
        }

        public async Task<Spaceships> PostSpaceAsync(SpaceshipModel model)
        {
            var spaceship = _mapper.Map<Spaceships>(model);

            if (spaceship.Notifications.Any())
            {
                return spaceship;
            }

            _spaceships.Add(spaceship);

            return spaceship;

        }

        public Task<Spaceships> RankUp(Guid spaceshipId)
        {
            throw new NotImplementedException();
        }

        public Task<Spaceships> Repair(Guid spaceshipId)
        {
            throw new NotImplementedException();
        }

        public Task<Spaceships> SendOnMission(Guid spaceshipId, Mission mission)
        {
            throw new NotImplementedException();
        }
    }
}
