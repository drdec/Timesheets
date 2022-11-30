using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{
    public class SheetRepository : ISheetRepository
    {
        private readonly TimesheetDbContext _context;

        public SheetRepository(TimesheetDbContext context)
        {
            _context = context;
        }

        public async Task Add(Sheet item)
        {
            await _context.Sheets.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Sheet> GetItem(Guid id)
        {
            var result = await _context.Sheets.FindAsync(id);

            return result;
        }

        public async Task<IEnumerable<Sheet>> GetItems()
        {
            var result = await _context.Sheets.ToListAsync();

            return result;
        }

        public async Task Update(Sheet item)
        {
            _context.Sheets.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Sheet>> GetItemsForInvoice(Guid contractId, DateTime dateStart, DateTime dateEnd)
        {
            var sheet = await _context.Sheets
                .Where(x => x.ContractId == contractId)
                .Where(x => x.Date <= dateEnd && x.Date >= dateStart)
                .Where(x => x.InvoiceId == null)
                .ToListAsync();

            return sheet;
        }
    }
}
