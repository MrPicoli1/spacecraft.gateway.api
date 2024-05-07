using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Spaceship.Gateway.Data.Repositories;
using Spaceship.Gateway.Domain.Entities;
using Spaceship.Gateway.Domain.ValueObjects;
using Spaceship.Gateway.Models.User;
using Spaceship.Gateway.Services.Interfaces;

namespace Spaceship.Gateway.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly SpaceshipMySQLContext _mySQLContext;

        public UserService(IMapper mapper, SpaceshipMySQLContext mySQLContext)
        {
            _mapper = mapper;
            _mySQLContext = mySQLContext;
        }

        public async Task<User> AddUserAsync(UserModel model)
        {
            var user = _mapper.Map<User>(model);

            var exists = await _mySQLContext.Users.Where(x => x.Deleted == false)
                .FirstOrDefaultAsync(x => x.Login.Username == user.Login.Username);

            if (exists != null)
            {
                user.AddNotification(user.Login.Username.ToString(), "Username ja existe");
                return user;
            }
            try
            {
                if (user.Notifications.Any())
                {
                    return user;
                }
                await _mySQLContext.Users.AddAsync(user);
                await _mySQLContext.SaveChangesAsync();
            }
            catch(Exception e)
            {
                user.AddNotification("AddUserAsync", $"Error when creating the user {e}");
            }
            return user;
        }

        public async Task<bool> DeleteUserAsync(Guid Id)
        {
            var user = _mySQLContext.Users.FirstOrDefault(x => x.Id == Id);

            if (user == null)
            {
                return false;
            }

            user.Delete();

            _mySQLContext.Users.Update(user);
            await _mySQLContext.SaveChangesAsync();

            return true;
        }

        public async Task<User> UpdateInfoUserAsync(UpdateInfoModel model)
        {

            var user = await _mySQLContext.Users.Where(x => x.Deleted == false).FirstOrDefaultAsync(x => x.Id ==model.Id);


            if (user == null)
            {
                return null;
            }

            var name = _mapper.Map<Name>(model.Name);
            var address = _mapper.Map<Address>(model.Address);

            user.UpdateInfo(name, address);

            if (user.Notifications.Any())
            {
                return user;
            }

            _mySQLContext.Update(user);
            await _mySQLContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> UpdateLoginUserAsync(UpdateLoginModel model)
        {
            

            var exists = await _mySQLContext.Users.Where(x => x.Deleted == false)
                .FirstOrDefaultAsync(x => x.Login.Username == model.Login.Username);

            if (exists != null)
            {
                exists.AddNotification(model.Login.Username.ToString(), "Username already exists");
                return exists;
            }

            var user =await _mySQLContext.Users.Where(x => x.Deleted == false).FirstOrDefaultAsync(x => x.Id == model.Id);


            if (user == null)
            {
                return null;
            }

            var login = _mapper.Map<Login>(model.Login);

            user.UpdateLogin(login);

            if (user.Notifications.Any())
            {
                return user;
            }

            _mySQLContext.Users.Update(user);
            await _mySQLContext.SaveChangesAsync();

            return user;
        }
    }
}
