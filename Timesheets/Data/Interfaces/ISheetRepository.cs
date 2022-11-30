using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Models;

namespace Timesheets.Data.Interfaces
{
    public interface ISheetRepository : IRepositoryBase<Sheet>
    {
        Task<IEnumerable<Sheet>> GetItemsForInvoice(Guid contractId, DateTime dateStart, DateTime dateEnd);
    }
}
