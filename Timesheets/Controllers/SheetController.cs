using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Controllers
{
    [ApiController]
    [Route("SheetController")]
    public class SheetController : ControllerBase
    {
        private readonly ISheetManager _sheetManager;

        public SheetController(ISheetManager sheetManager)
        {
            _sheetManager = sheetManager;
        }

        [HttpGet("get-item")]
        public async Task<IActionResult> GetResult(Guid id)
        {
            var res = await _sheetManager.GetItem(id);
            return Ok(res);
        }

        [HttpGet("get-all-items")]
        public async Task<IActionResult> GetAllItems()


        {
            var res = await _sheetManager.GetItems();

            return Ok(res);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] SheetDto sheet)
        {
            var res = await _sheetManager.Create(sheet);
            return Ok(res);
        }
    }
}
