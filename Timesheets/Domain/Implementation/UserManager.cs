using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;
using Timesheets.Models.Request;

namespace Timesheets.Domain.Implementation
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> Create(UserRequest item)
        {
            var user = new User
            {
                Id = new Guid(),
                UserName = item.UserName,
                PasswordHash = GetPasswordHash(item.Password),
                Role = item.Role
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

        public async Task Update(Guid id, UserRequest user)
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

        public async Task<User> GetUser(LoginRequest request)
        {
            var passwordHash = GetPasswordHash(request.Password);
            var user = await _userRepository.GetByLoginAndPasswordHash(request.Login, passwordHash);
            return user;
        }

        private static byte[] GetPasswordHash(string password)
        {
            using (var temp = new SHA1CryptoServiceProvider())
            {
                return temp.ComputeHash(Encoding.Unicode.GetBytes(password));
            }
        }
    }
}
