using System;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Domain.Interfaces;
using Timesheets.Models.Dto;

namespace Timesheets.Controllers
{
    public class UsersController : TimesheetBaseController
    {
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("get-item/{id}")]
        public async Task<IActionResult> GetItem([FromQuery]Guid id)
        {
            var res = await _userManager.GetItem(id);
            return Ok(res);
        }

        [HttpGet("get-all-items")]
        [Authorize(Roles = "user,admin")]
        public async Task<IActionResult> GetAllItems()
        {
            var res = await _userManager.GetAllItems();
            return Ok(res.ToList());
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] UserRequest item)
        {
            var res = await _userManager.Create(item);
            return Ok(res);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateItem([FromBody]Guid id, [FromRoute] UserRequest user)
        {
            await _userManager.Update(id, user);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteItem([FromQuery]Guid id)
        {
            await _userManager.Delete(id);
            return Ok();
        }
    }
}
