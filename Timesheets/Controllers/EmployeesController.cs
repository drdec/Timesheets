using System;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Timesheets.Domain.Interfaces;
using Timesheets.Models.Dto;

namespace Timesheets.Controllers
{
    public class EmployeesController : TimesheetBaseController
    {
        private readonly IEmployeeManager _employeeManager;

        public EmployeesController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        [HttpGet("get-item/")]
        public async Task<IActionResult> GetItem([FromHeader]Guid id)
        {
            var res = await _employeeManager.GetItem(id);
            return Ok(res);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(EmployeeRequest employee)
        {
            var res = await _employeeManager.Create(employee);
            return Ok(res);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(Guid id, EmployeeRequest employee)
        {
            await _employeeManager.Update(id, employee);
            return Ok();
        }

        [HttpGet("get-all-items")]
        public async Task<IActionResult> GetAllItems()
        {
            var res = await _employeeManager.GetAllItems();
            return Ok(res.ToList());
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _employeeManager.Delete(id);
            return Ok();
        }
    }
}
