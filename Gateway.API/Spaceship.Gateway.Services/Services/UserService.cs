using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spaceship.Gateway.Data.Repositories;
using Spaceship.Gateway.Domain.Entities;
using Spaceship.Gateway.Models.User;
using Spaceship.Gateway.Services.Interfaces;

namespace Spaceship.Gateway.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly SpaceshipMySQLContext _mySQLContext;

        public UserService(IMapper mapper, SpaceshipMySQLContext mySQLContext = null)
        {
            _mapper = mapper;
            _mySQLContext = mySQLContext;
        }



        public async Task<User> AddUserAsync(UserModel model)
        {


            var user = _mapper.Map<User>(model);

            var exists = await _mySQLContext.Users.Where(x => x.Deleted == false).FirstOrDefaultAsync(x => x.Login.Username == user.Login.Username);

            if (exists != null)
            {
                user.AddNotification(user.Login.Username.ToString(), "Username ja existe");
                return user;
            }
            try
            {
                await _mySQLContext.Users.AddAsync(user);
                await _mySQLContext.SaveChangesAsync();
            }
            catch
            {
                user.AddNotification("AddUserAsync", "Error when creating the user");
            }
            return user;
        }

        public async Task<bool> DeleteUserAsync(Guid Id)
        {
            var user = _mySQLContext.Users.FirstOrDefault(x => x.Id == Id);

            if (user != null)
            {
                return false;
            }

            user.Delete();

            _mySQLContext.Users.Update(user);
            await _mySQLContext.SaveChangesAsync();

            return true;
        }

        public async Task<User> UpdateInfoUserAsync(UserModel model)
        {
            var updateInfo = _mapper.Map<User>(model);

            var user = await _mySQLContext.Users.Where(x => x.Deleted == false).FirstOrDefaultAsync(x => x.Login.Username == updateInfo.Login.Username);

            if (user == null)
            {
                updateInfo.AddNotification(updateInfo.Login.Username.ToString(), "Username nao existe");
                return updateInfo;
            }

            user.UpdateInfo(updateInfo);

            _mySQLContext.Update(user);
            await _mySQLContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> UpdateLoginUserAsync(UserModel model)
        {
            var updateLogin = _mapper.Map<User>(model);

            var user =await _mySQLContext.Users.Where(x => x.Deleted == false).FirstOrDefaultAsync(x => x.Id == updateLogin.Id);

            if (user == null)
            {
                updateLogin.AddNotification(updateLogin.Login.Username.ToString(), "Username nao existe");
                return updateLogin;
            }

            user.UpdateLogin(updateLogin.Login);
            _mySQLContext.Users.Update(user);
            await _mySQLContext.SaveChangesAsync();

            return user;
        }
    }
}
