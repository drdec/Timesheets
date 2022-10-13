using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Interfaces
{
    public interface IEmployeeManager
    {
        Task<Employee> GetItem(Guid id);
        Task<IEnumerable<Employee>> GetAllItems();
        Task<Guid> Create(EmployeeRequest item);
        Task Update(Guid id, EmployeeRequest user);
        Task Delete(Guid id);
    }
}
