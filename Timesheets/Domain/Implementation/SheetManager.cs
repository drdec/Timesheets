using System;
using Timesheets.Data.Implementation;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Interfaces;
using Timesheets.Models;

namespace Timesheets.Domain.Implementation
{
    public class SheetManager : ISheetManager
    {
        private readonly ISheetRepository _sheetRepository;

        public SheetManager(ISheetRepository sheetRepository)
        {
            _sheetRepository = sheetRepository;
        }

        public Sheet GetItem(Guid id)
        {
            return _sheetRepository.GetItem(id);
        }
    }
}
