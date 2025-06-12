using EffortTracker.Models;
using EffortTracker.Repository;
using EffortTracker.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EffortTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("MyCorsPolicy")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IAuthentication _auth;

        public UsersController(IUsersService usersService,IAuthentication auth)
        {
            _usersService = usersService;
            _auth = auth;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetAllUsers()
        {
            var users = await _usersService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUserById(int id)
        {
            var user = await _usersService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> AddUser([FromBody] Users user)
        {
            await _usersService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.associate_id }, user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] Users user)
        {
            if (id != user.associate_id)
                return BadRequest("User ID mismatch");

            await _usersService.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _usersService.DeleteUserAsync(id);
            return NoContent();
        }

        [AllowAnonymous]
        [HttpPost("authentication")]
        public IActionResult AuthenticationCheck([FromBody] AuthenticationRequest request) //Use a specific request model
        {
            var token = _auth.AuthenticationUser(request.associate_id, request.password);
            if (token == null)
                return Unauthorized();
            return Ok(new { Token = token });
        }

    }
    public class AuthenticationRequest
    {
        public int associate_id { get; set; }
        public string password { get; set; }

    }
}

