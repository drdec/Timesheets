using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.AspNetCore.Mvc;
using Timesheets.Models.Dto;

namespace Timesheets.Controllers
{
    [ApiController]
    [Route("SheetsController")]
    public class UsersController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetItem([FromQuery]Guid id)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllItem()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserDto item)
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateItem([FromBody]Guid id, [FromRoute] UserDto user)
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteItem([FromQuery]Guid id)
        {
            return Ok();
        }
    }
}
