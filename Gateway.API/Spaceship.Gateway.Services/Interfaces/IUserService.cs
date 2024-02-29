using Spaceship.Gateway.Domain.Entities;
using Spaceship.Gateway.Models.User;

namespace Spaceship.Gateway.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> AddUser(UserModel model);
        Task<User> UpdateUser(UserModel model);
        Task DeleteUser(UserModel model);


    }
}
