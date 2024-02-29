using AutoMapper;
using Spaceship.Gateway.Domain.Entities;
using Spaceship.Gateway.Domain.ValueObjects;
using Spaceship.Gateway.Models.Mission;
using Spaceship.Gateway.Models.Spaceship;
using Spaceship.Gateway.Models.User;
using Spaceship.Gateway.Models.ValueObjects;

namespace Spaceship.Gateway.Domain.Profiles
{
    public class SpaceshipProfiles : Profile
    {
        public SpaceshipProfiles() 
        {
            CreateMap<UserModel, User>();
            CreateMap<MissionModel, Mission>();
            CreateMap<SpaceshipModel, Spaceships>();

            CreateMap<AddressModel, Address>();
            CreateMap<DifficultyModel, Difficulty>();
            CreateMap<EmailModel, Email>();
            CreateMap<LoginModel, Login>();
            CreateMap<MaterialModel, Material>();
            CreateMap<NameModel, Name>();
            CreateMap<StatusModel,Status>();
        }
    }
}
