using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly TimesheetDbContext _timesheetDbContext;

        public UserRepository(TimesheetDbContext timesheetDbContext)
        {
            _timesheetDbContext = timesheetDbContext;
        }

        public async Task Add(User item)
        {
            await _timesheetDbContext.Users.AddAsync(item);
            await _timesheetDbContext.SaveChangesAsync();
        }

        public async Task<User> GetItem(Guid id)
        {
            var res = await _timesheetDbContext.Users.FindAsync(id);
            return res;
        }

        public async Task<IEnumerable<User>> GetItems()
        {
            var result = await _timesheetDbContext.Users.ToListAsync();
            return result;
        }

        public async Task Update(User item)
        {
            _timesheetDbContext.Users.Update(item);
            await _timesheetDbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var user = await _timesheetDbContext.Users.FindAsync(id);
            _timesheetDbContext.Users.Attach(user);
            _timesheetDbContext.Users.Remove(user);
            await _timesheetDbContext.SaveChangesAsync();
        }
    }
}
