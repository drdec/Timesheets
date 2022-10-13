using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Interfaces
{
    public interface ISheetManager
    {
        Task<Sheet> GetItem(Guid Id);
        Task<Guid> Create(SheetRequest sheet);
        Task<IEnumerable<Sheet>> GetItems();
        void Update(Guid id, SheetRequest sheet);
    }
}
