using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly TimesheetDbContext _timesheetDbContext;

        public EmployeeRepository(TimesheetDbContext timesheetDbContext)
        {
            _timesheetDbContext = timesheetDbContext;
        }

        public async Task Add(Employee item)
        {
            await _timesheetDbContext.Employees.AddAsync(item);
            await _timesheetDbContext.SaveChangesAsync();
        }

        public async Task<Employee> GetItem(Guid id)
        {
            var res = await _timesheetDbContext.Employees.FindAsync(id);
            return res;
        }

        public async Task<IEnumerable<Employee>> GetItems()
        {
            var result = await _timesheetDbContext.Employees.ToListAsync();
            return result;
        }

        public async Task Update(Employee item)
        {
            _timesheetDbContext.Employees.Update(item);
            await _timesheetDbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var item = await _timesheetDbContext.Employees.FindAsync(id);
            item.IsDeleted = true;
            _timesheetDbContext.Employees.Update(item);
            await _timesheetDbContext.SaveChangesAsync();
        }
    }
}
