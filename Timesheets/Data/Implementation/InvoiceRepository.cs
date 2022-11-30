using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly TimesheetDbContext _timesheetDbContext;

        public InvoiceRepository(TimesheetDbContext timesheetDbContext)
        {
            _timesheetDbContext = timesheetDbContext;
        }

        public Task<Invoice> GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Invoice>> GetItems()
        {
            throw new NotImplementedException();
        }

        public async Task Add(Invoice item)
        {
            await _timesheetDbContext.Invoices.AddAsync(item);
            await _timesheetDbContext.SaveChangesAsync();
        }

        public Task Update(Invoice item)
        {
            throw new NotImplementedException();
        }
    }
}
