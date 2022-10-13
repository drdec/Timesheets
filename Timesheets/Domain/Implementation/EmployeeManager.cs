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
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeManager(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Guid> Create(EmployeeRequest item)
        {
            var employee = new Employee()
            {
                Id = new Guid(),
                IsDeleted = false,
                UserId = item.UserId
            };

            await _employeeRepository.Add(employee);


            return employee.Id;
        }

        public async Task Delete(Guid id)
        {
            await _employeeRepository.Delete(id);
        }

        public async Task<IEnumerable<Employee>> GetAllItems()
        {
            var res = await _employeeRepository.GetItems();
            return res.ToList();
        }

        public async Task<Employee> GetItem(Guid id)
        {
            var res = await _employeeRepository.GetItem(id);
            return res;
        }

        public async Task Update(Guid id, EmployeeRequest user)
        {
            var item = new Employee()
            {
                Id = id,
                IsDeleted = false,
                UserId = user.UserId
            };

            await _employeeRepository.Update(item);
        }
    }
}
