using System;
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

        public async Task<Guid> Create(SheetDto sheetDto)
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
    }
}
