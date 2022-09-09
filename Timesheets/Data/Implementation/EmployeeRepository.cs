using System;
using System.Collections.Generic;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public void Add(Employee item)
        {
            throw new NotImplementedException();
        }

        public Employee GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetItems()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
