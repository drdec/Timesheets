using System;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Data.Interfaces
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        public Task Delete(Guid id);
    }
}
