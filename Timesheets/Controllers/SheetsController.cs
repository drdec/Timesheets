using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Controllers
{
    [ApiController]
    [Route("api/sheet")]
    public class SheetsController : ControllerBase
    {
        private readonly ISheetManager _sheetManager;
        private readonly IContractManager _contractManager;

        public SheetsController(ISheetManager sheetManager, IContractManager contractManager)
        {
            _sheetManager = sheetManager;
            _contractManager = contractManager;
        }

        [HttpGet("[controller]/get-item")]
        public async Task<IActionResult> GetResult([FromQuery] Guid id)
        {
            var res = await _sheetManager.GetItem(id);
            return Ok(res);
        }

        [HttpGet("[controller]/get-all-items")]
        public async Task<IActionResult> GetAllItems()
        {
            var res = await _sheetManager.GetItems();

            return Ok(res);
        }

        /// <summary>
        /// Возвращает запись табеля 
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        [HttpPost("[controller]/create")]
        public async Task<IActionResult> Create([FromBody] SheetRequest sheet)
        {
            var isAllowedToCreate = await _contractManager.CheckContractIsActive(sheet.ContractId);

            if (isAllowedToCreate == null || (bool)!isAllowedToCreate)
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
        [HttpPut("[controller]/update/{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] SheetRequest sheet)
        {
            var isAllowedToCreate = await _contractManager.CheckContractIsActive(sheet.ContractId);

            if (isAllowedToCreate == null || (bool)!isAllowedToCreate)
            {
                return BadRequest($"Contract {sheet.ContractId} is not active or not found!");
            }

            _sheetManager.Update(id, sheet);

            return Ok();
        }
    }
}
