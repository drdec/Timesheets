using System;
using System.Threading.Tasks;
using Timesheets.Models;

namespace Timesheets.Data.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        public Task Delete(Guid id);
        Task<User> GetByLoginAndPasswordHash(string requestLogin, byte[] passwordHash);
    }
}
 