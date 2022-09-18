using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{
    public class UserRepository : IUserRepository
    {
        public async Task Add(User item)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetItems()
        {
            throw new System.NotImplementedException();
        }

        public async Task Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
