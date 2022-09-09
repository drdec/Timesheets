using System;
using System.Collections.Generic;
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

        [HttpGet]
        public IActionResult GetResult(Guid id)
        {
            var res = _sheetManager.GetItem(id);
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Create([FromBody] SheetDto sheet)
        {
            var res = _sheetManager.Create(sheet);
            return Ok(res);
        }
    }
}
