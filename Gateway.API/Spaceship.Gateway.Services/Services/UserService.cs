using AutoMapper;
using Spaceship.Gateway.Domain.Entities;
using Spaceship.Gateway.Models.User;
using Spaceship.Gateway.Services.Interfaces;
using System.Diagnostics.Metrics;

namespace Spaceship.Gateway.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;

        private List<User> _users;

        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<User> AddUser(UserModel model)
        {
            var user = _mapper.Map<User>(model);

            return user;
        }

        public Task DeleteUser(UserModel model)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(UserModel model)
        {
            throw new NotImplementedException();
        }
    }
}
