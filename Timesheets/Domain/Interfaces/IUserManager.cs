using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.Dto;
using Timesheets.Models.Request;

namespace Timesheets.Domain.Interfaces
{
    public interface IUserManager
    {
        Task<User> GetItem(Guid id);
        Task<IEnumerable<User>> GetAllItems();
        Task<Guid> Create(UserRequest item);
        Task Update(Guid id, UserRequest user);
        Task Delete(Guid id);
        Task<User> GetUser(LoginRequest request);
    }
}
