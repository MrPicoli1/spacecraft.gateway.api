using Spaceship.Gateway.Domain.Entities;
using Spaceship.Gateway.Models.User;

namespace Spaceship.Gateway.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> AddUserAsync(UserModel model);
        Task<User> UpdateInfoUserAsync(UserModel model);
        Task<User> UpdateLoginUserAsync(UserModel model);
        Task<bool> DeleteUserAsync(Guid Id);


    }
}
