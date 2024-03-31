using AutoMapper;
using Spaceship.Gateway.Domain.Entities;
using Spaceship.Gateway.Models.User;
using Spaceship.Gateway.Services.Interfaces;

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

      

        public async Task<User> AddUserAsync(UserModel model)
        {


            var user = _mapper.Map<User>(model);

            var exists = _users.Where(x => x.Deleted == false).FirstOrDefault(x => x.Login.Username == user.Login.Username);

            //if (exists != null)
            //{
            //    user.AddNotification(user.Login.Username , "Username ja existe");
            //}

            //if (user.Notifications.Any())
            //{
            //    return user;
            //}

            _users.Add(user);

            return user;
        }

        public async Task<bool> DeleteUserAsync(Guid Id)
        {
            var exists = _users.FirstOrDefault(x => x.Id == Id);

            if (exists != null)
            {
                return false;
            }


            _users.FirstOrDefault(x => x.Id == Id).Delete();


            return true;
        }

        public async Task<User> UpdateInfoUserAsync(UserModel model)
        {
            var user = _mapper.Map<User>(model);

            var exists = _users.Where(x => x.Deleted == false).FirstOrDefault(x => x.Login.Username == user.Login.Username);

            //if (exists == null)
            //{
            //    user.AddNotification(user.Login.Username, "Username nao existe");
            //}

            //if (user.Notifications.Any())
            //{
            //    return user;
            //}

            _users.FirstOrDefault(x => x.Id == user.Id).UpdateInfo(user);

            return user;
        }

        public async Task<User> UpdateLoginUserAsync(UserModel model)
        {
            var user = _mapper.Map<User>(model);

            var exists = _users.Where(x => x.Deleted == false).FirstOrDefault(x => x.Id == user.Id);

            //if (exists == null)
            //{
            //    user.AddNotification(user.Login.Username, "Username nao existe");
            //}

            //if (user.Notifications.Any())
            //{
            //    return user;
            //}

            _users.FirstOrDefault(x => x.Id == user.Id).UpdateLogin(user.Login);

            return user;
        }  
    }
}
