using Backend;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService) => _usersService = usersService;

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] UserDTO userDTO)
        {
            var user = await _usersService.CreateUserAsync(userDTO);
            return Ok(user);

        }

        [HttpGet]
        public async Task<ActionResult> GetAllUsers()
        {
            var users = await _usersService.GetAllUsersAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserById(Guid id)
        {
            var user = await _usersService.GetUserByIdAsync(id);

            if (user is null) return NotFound();

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(Guid id, [FromBody] UserDTO userDTO)
        {
            var result = await _usersService.UpdateUserAsync(id, userDTO);

            if (result is null) return BadRequest();

            return Ok(result);


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            var result = await _usersService.DeleteUserAsync(id);

            if (result == false) return BadRequest("User Not Found");

            return Ok("User Deleted");
        }
    }
}
