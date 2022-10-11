using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Interfaces
{
    public interface IUserManager
    {
        Task<User> GetItem(Guid id);
        Task<IEnumerable<User>> GetAllItems();
        Task<Guid> Create(UserDto item);
        Task Update(Guid id, UserDto user);
        Task Delete(Guid id);
    }
}
