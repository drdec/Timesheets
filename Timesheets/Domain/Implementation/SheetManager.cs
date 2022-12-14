using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Data.Implementation;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Implementation
{
    public class SheetManager : ISheetManager
    {
        private readonly ISheetRepository _sheetRepository;

        public SheetManager(ISheetRepository sheetRepository)
        {
            _sheetRepository = sheetRepository;
        }

        public async Task<Sheet> GetItem(Guid id)
        {
            return await _sheetRepository.GetItem(id);
        }

        public async Task<Guid> Create(SheetRequest sheetDto)
        {
            var sheet = new Sheet()
            {
                Id = Guid.NewGuid(),
                Amount = sheetDto.Amount,
                ContractId = sheetDto.ContractId,
                Date = sheetDto.Date,
                EmployeeId = sheetDto.EmployeeId,
                ServiceId = sheetDto.ServiceId
            };

            await _sheetRepository.Add(sheet);

            return sheet.Id;
        }

        public async Task<IEnumerable<Sheet>> GetItems()
        {
            var result = await _sheetRepository.GetItems();

            return result;
        }

        public void Update(Guid id, SheetRequest sheet)
        {
            var item = new Sheet()
            {
                Id = id,
                Amount = sheet.Amount,
                ContractId = sheet.ContractId,
                Date = sheet.Date,
                EmployeeId = sheet.EmployeeId,
                ServiceId = sheet.ServiceId
            };

            _sheetRepository.Update(item);
        }
    }
}
