using Spaceship.Gateway.Domain.Entities;
using Spaceship.Gateway.Models.User;

namespace Spaceship.Gateway.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> AddUser(UserModel model);
        Task<User> UpdateInfoUser(UserModel model);
        Task<User> UpdateLoginUser(UserModel model);
        Task<bool> DeleteUser(Guid Id);


    }
}
