using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Controllers
{
    public class SheetsController : TimesheetBaseController
    {
        private readonly ISheetManager _sheetManager;
        private readonly IContractManager _contractManager;

        public SheetsController(ISheetManager sheetManager, IContractManager contractManager)
        {
            _sheetManager = sheetManager;
            _contractManager = contractManager;
        }

        /// <summary>
        /// Возвращает по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get-item")]
        public async Task<IActionResult> GetResult([FromQuery] Guid id)
        {
            var res = await _sheetManager.GetItem(id);
            return Ok(res);
        }

        [HttpGet("get-all-items")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAllItems()
        {
            var res = await _sheetManager.GetItems();

            return Ok(res);
        }

        /// <summary>
        /// Создает запись табеля 
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        [HttpPost("create")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([FromBody] SheetRequest sheet)
        {
            if (await IsAllowedToCreate(sheet))
            {
                return BadRequest($"Contract {sheet.ContractId} is not active or not found!");
            }

            var res = await _sheetManager.Create(sheet);
            return Ok(res);
        }

        /// <summary>
        /// Обновляет запись табеля
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sheet"></param>
        /// <returns></returns>
        [HttpPut("update/{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] SheetRequest sheet)
        {
            if (await IsAllowedToCreate(sheet))
            {
                return BadRequest($"Contract {sheet.ContractId} is not active or not found!");
            }

            _sheetManager.Update(id, sheet);

            return Ok();
        }

        private async Task<bool> IsAllowedToCreate(SheetRequest sheet)
        {
            var isAllowedToCreate = await _contractManager.CheckContractIsActive(sheet.ContractId);

            return isAllowedToCreate == null || (bool) !isAllowedToCreate;
        }
    }
}
