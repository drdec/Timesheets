using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{
    public class ContractRepository : IContractRepository
    {
        private readonly TimesheetDbContext _timesheetDbContext;

        public ContractRepository(TimesheetDbContext timesheetDbContext)
        {
            _timesheetDbContext = timesheetDbContext;
        }

        public async Task Add(Contract item)
        {
            throw new NotImplementedException();
        }

        public async Task<Contract> GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Contract>> GetItems()
        {
            throw new NotImplementedException();
        }

        public async Task Update(Contract item)
        {
            _timesheetDbContext.Contracts.Update(item);
            await _timesheetDbContext.SaveChangesAsync();
        }

        public async Task<bool?> CheckContractIsActive(Guid id)
        {
            var contract = await _timesheetDbContext.Contracts.FindAsync(id);
            var now = DateTime.Now;
            var isActive = now <= contract?.DateEnd && now >= contract?.DateStart;

            return isActive;    
        }
    }
}
