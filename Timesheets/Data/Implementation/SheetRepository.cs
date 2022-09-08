using System;
using System.Collections.Generic;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{
    public class SheetRepository : ISheetRepository
    {
        private List<Sheet> Sheets { get; set; } = new List<Sheet>()

        public void Add()
        {
            throw new System.NotImplementedException();
        }

        public Sheet GetItem(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sheet> GetItems()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
