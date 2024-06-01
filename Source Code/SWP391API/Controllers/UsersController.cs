using Microsoft.AspNetCore.Mvc;
using SWP391API.Attributes;
using SWP391API.Domain.Contracts;
using SWP391API.Domain.Models;
using SWP391API.Models;

namespace SWP391API.Controllers
{
    [Route("api/[controller]")] //    /api/Users
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest model)
        {
            var response = await _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User userObj)
        {
            userObj.Id = 0;
            return Ok(await _userService.AddAndUpdateUser(userObj));
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User userObj)
        {
            return Ok(await _userService.AddAndUpdateUser(userObj));
        }
    }
}
