using System;
using System.Collections.Generic;
using System.Linq;
using Timesheets.Data.Interfaces;
using Timesheets.Models;

namespace Timesheets.Data.Implementation
{
    public class SheetRepository : ISheetRepository
    {
        private static List<Sheet> Sheets { get; set; } = new List<Sheet>()
        {
            new Sheet
            {
                Id = Guid.Parse("5D96E6B8-ED02-D4BC-31C5-ED2B809EF7C8"),
                Date = new DateTime(20,04,29),
                EmployeeId =  Guid.Parse("45C55020-A7E8-1A46-924C-42E3B9AED664"),
                ContractId =  Guid.Parse("11FC2E6C-9289-ACC8-ACC3-5150E5673116"),
                ServiceId =  Guid.Parse("42AE1C67-9C8B-3EFE-AA53-7FDF07AAC090"),
                Amount = 5
            },
            new Sheet
            {
                Id =  Guid.Parse("F26B72D7-01EE-76AC-E0A9-9B688ED97183"),
                Date = new DateTime(18,12,29),
                EmployeeId =  Guid.Parse("1FE89315-3ED1-BBD6-B356-8F174ADE98E2"),
                ContractId =  Guid.Parse("9DCEE4E2-848C-6A76-DDCC-E271E7DB76AF"),
                ServiceId =  Guid.Parse("ED7A7C52-0A73-E620-62A3-4DE63415FD9B"),
                Amount = 6
            },
            new Sheet
            {
                Id =  Guid.Parse("0A71277D-972F-9945-BA3C-7CD1261F5869"),
                Date = new DateTime(18,12,26),
                EmployeeId =  Guid.Parse("36CD2370-467B-CCBC-EC90-DB8E38684E97"),
                ContractId =  Guid.Parse("8B983292-55CE-E7EA-0E11-3E3147728E8B"),
                ServiceId =  Guid.Parse("12FB4581-0F3D-C56D-7165-14C8222B1D95"),
                Amount = 6
            },
            new Sheet   
            {
                Id =  Guid.Parse("923B59E3-C814-4CD1-2486-D93C11624497"),
                Date =  new DateTime(20,01,15),
                EmployeeId =  Guid.Parse("6D57B96D-E4FA-1631-4EA3-F7CFAC62C394"),
                ContractId =  Guid.Parse("1B32DB10-335E-9A36-9A3E-82B7C572DBA1"),
                ServiceId =  Guid.Parse("B0AA895E-872F-DA18-192E-2039CD751CCA"),
                Amount = 6
            }
        };

        public void Add(Sheet item)
        {
            Sheets.Add(item);
        }

        public Sheet GetItem(Guid id)
        {
            return Sheets.FirstOrDefault(x => x.Id == id);
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
