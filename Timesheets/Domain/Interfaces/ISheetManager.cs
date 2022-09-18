using System;
using System.Threading.Tasks;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Interfaces
{
    public interface ISheetManager
    {
        Task<Sheet> GetItem(Guid Id);
        Task<Guid> Create(SheetDto sheet);
    }
}
