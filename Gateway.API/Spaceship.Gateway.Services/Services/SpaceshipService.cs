using AutoMapper;
using Spaceship.Gateway.Domain.Entities;
using Spaceship.Gateway.Extensions.Http;
using Spaceship.Gateway.Models.Spaceship;
using Spaceship.Gateway.Services.Interfaces;

namespace Spaceship.Gateway.Services.Services
{
    public class SpaceshipService : ISpaceshipService
    {
        private List<Spaceships> _spaceships;
        private readonly IMapper _mapper;
        private readonly HttpClientExtensions _httpClient;

        public SpaceshipService(IMapper mapper, HttpClientExtensions httpClient)
        {
            _mapper = mapper;
            _httpClient = httpClient;
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
            var url = "https://localhost:7414/";
            var responseMessage = await _httpClient.GetList<SpaceshipModel>(url);
            if (responseMessage != null)
            {
                return responseMessage;
            }

            return null;
        }

        public async Task<Spaceships> PostSpaceAsync(SpaceshipModel model)
        {
            var spaceship = _mapper.Map<Spaceships>(model);

            //if (spaceship.Notifications.Any())
            //{
            //    return spaceship;
            //}

            _spaceships.Add(spaceship);

            return spaceship;

        }

        public async Task<Spaceships> RankUp(Guid spaceshipId)
        {
           _spaceships.FirstOrDefault(x=>x.Id == spaceshipId)?.RankUp();
            return _spaceships.FirstOrDefault(x => x.Id == spaceshipId);
        }

        public async Task<Spaceships> Repair(Guid spaceshipId, int currency)
        {
            var spaceship = _spaceships.FirstOrDefault(x => x.Id == spaceshipId);
            int porcentage = currency / spaceship!.Status.RepairCost;
            _spaceships.FirstOrDefault(x => x.Id == spaceshipId)?.Repair(porcentage);
            return _spaceships.FirstOrDefault(x => x.Id == spaceshipId);
        }

    }
}
