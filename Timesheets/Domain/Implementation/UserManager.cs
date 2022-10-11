using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Implementation
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> Create(UserDto item)
        {
            var user = new User
            {
                Id = new Guid(),
                UserName = item.UserName
            };

            await _userRepository.Add(user);

            return user.Id;
        }

        public async Task<IEnumerable<User>> GetAllItems()
        {
            var result = await _userRepository.GetItems();
            return result.ToList();
        }

        public async Task<User> GetItem(Guid id)
        {
            var result = await _userRepository.GetItem(id);
            return result;
        }

        public async Task Update(Guid id, UserDto user)
        {
            var item = new User()
            {
                Id = id,
                UserName = user.UserName
            };

            await _userRepository.Update(item);
        }

        public async Task Delete(Guid id)
        {
            await _userRepository.Delete(id);
        }
    }
}
