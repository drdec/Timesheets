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
    [Route("api/sheets")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeManager _employeeManager;

        public EmployeesController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        [HttpGet("[controller]/get-item/{id}")]
        public async Task<IActionResult> GetItem(Guid id)
        {
            var res = await _employeeManager.GetItem(id);
            return Ok(res);
        }

        [HttpPost("[controller]/create")]
        public async Task<IActionResult> Create(EmployeeRequest employee)
        {
            var res = await _employeeManager.Create(employee);
            return Ok(res);
        }

        [HttpPut("[controller]/update")]
        public async Task<IActionResult> Update(Guid id, EmployeeRequest employee)
        {
            await _employeeManager.Update(id, employee);
            return Ok();
        }

        [HttpGet("[controller]/get-all-items")]
        public async Task<IActionResult> GetAllItems()
        {
            var res = await _employeeManager.GetAllItems();
            return Ok(res.ToList());
        }

        [HttpDelete("[controller]/delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _employeeManager.Delete(id);
            return Ok();
        }
    }
}
