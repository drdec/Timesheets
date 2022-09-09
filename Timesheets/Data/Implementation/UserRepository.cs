using System;
using System.Collections.Generic;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{
    public class UserRepository : IUserRepository
    {
        public void Add(User item)
        {
            throw new NotImplementedException();
        }

        public User GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetItems()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
