using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spaceship.Gateway.Data.Repositories;
using Spaceship.Gateway.Domain.Entities;
using Spaceship.Gateway.Extensions.Http;
using Spaceship.Gateway.Models.Spaceship;
using Spaceship.Gateway.Services.Interfaces;

namespace Spaceship.Gateway.Services.Services
{
    public class SpaceshipService : ISpaceshipService
    {
        private readonly IMapper _mapper;
        private readonly HttpClientExtensions _httpClient;
        private readonly SpaceshipMySQLContext _mySQLContext;

        public SpaceshipService(IMapper mapper, HttpClientExtensions httpClient, SpaceshipMySQLContext mySQLContext)
        {
            _mapper = mapper;
            _httpClient = httpClient;
            _mySQLContext = mySQLContext;
        }

        public async Task<bool> DeleteSpaceshipAsync(Guid spaceshipId)
        {
            var spaceship = await _mySQLContext.Spaceships.FirstOrDefaultAsync(x => x.Id == spaceshipId);

            if (spaceship != null)
            {
                return false;
            }
            spaceship.Delete();
            _mySQLContext.Spaceships.Update(spaceship);
            await _mySQLContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Spaceships>> GetAllSpaceshipsAsync(Guid userId)
        {
            return await _mySQLContext.Spaceships.Where(x => x.UserId.Equals(userId)).ToListAsync();
        }

        public async Task<List<SpaceshipModel>> GetNewSpaceshipsAsync()
        {
            var url = "https://localhost:7108/";
            var spaceshipList = await _httpClient.GetList<SpaceshipModel>(url);
            if (spaceshipList != null)
            {
                return (List<SpaceshipModel>)spaceshipList;
            }

            return null;
        }

        public async Task<Spaceships> PostSpaceAsync(SpaceshipModel model)
        {
            var user = await _mySQLContext.Users.FirstOrDefaultAsync(x => x.Id == model.UserId);
            
            if(user == null)
            {
                return null;
            }

            var spaceship = _mapper.Map<Spaceships>(model);

            if (spaceship.Notifications.Any())
            {
                return spaceship;
            }

            await _mySQLContext.Spaceships.AddAsync(spaceship);
            await _mySQLContext.SaveChangesAsync();

            return spaceship;

        }

        public async Task<Spaceships> RankUp(Guid spaceshipId)
        {
            var spaceship = await _mySQLContext.Spaceships.FirstOrDefaultAsync(x => x.Id == spaceshipId);
            var user = await _mySQLContext.Users.FirstOrDefaultAsync(x => x.Id == spaceship!.UserId);

            if (spaceship == null)
            {
                return null;
            }

            spaceship.RankUp();
            if (spaceship.Notifications.Any())
            {
                return spaceship;
            }

            _mySQLContext.Spaceships.Update(spaceship);
            await _mySQLContext.SaveChangesAsync();

            return spaceship;
        }

        public async Task<Spaceships> Repair(Guid spaceshipId)
        {
            var spaceship = await _mySQLContext.Spaceships.FirstOrDefaultAsync(x => x.Id == spaceshipId);
            var user = await _mySQLContext.Users.FirstOrDefaultAsync(x => x.Id == spaceship!.UserId);

            int porcentage = user.RepairSpaceship(spaceship!.Status.RepairCost) / spaceship!.Status.RepairCost;
            spaceship.Repair(porcentage);

            if (spaceship == null||user==null)
            {
                return null;
            }

            if (user.Notifications.Any())
            {
               spaceship.AddNotification("User",user.Notifications.FirstOrDefault());
            }

            if(spaceship.Notifications.Any())
            {
                return spaceship;
            }

            _mySQLContext.Spaceships.Update(spaceship);
            await _mySQLContext.SaveChangesAsync();

            _mySQLContext.Users.Update(user);
            await _mySQLContext.SaveChangesAsync();
            return spaceship;
        }

    }
}
