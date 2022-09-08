using System;
using Timesheets.Models;

namespace Timesheets.Domain.Interfaces
{
    public interface ISheetManager
    {
        Sheet GetItem(Guid Id);
    }
}
