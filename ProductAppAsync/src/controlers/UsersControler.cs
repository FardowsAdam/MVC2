using Microsoft.AspNetCore.Mvc;
using ProductAppAsync.src.services;
using ProductAppAsync.src.interfaces;
using ProductAppAsync.src.models;
namespace ProductAppAsync.src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserInterface _userService;

        public UsersController(UserInterface userService)
        {
            _userService = userService;
        }

        // GET: api/users
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid user ID");

                var user = await _userService.GetByIdAsync(id);
                if (user == null)
                    return NotFound($"User with ID {id} not found");

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/users
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            try
            {
                if (user == null)
                    return BadRequest("User data is required");

                if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Email))
                    return BadRequest("Name and Email are required fields");

                // Fixed typo: Adedress -> Address
                var newUser = await _userService.AddUserAsync(user.Name, user.Adedress, user.Email);
                
                return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid user ID");

                if (user == null)
                    return BadRequest("User data is required");

                if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Email))
                    return BadRequest("Name and Email are required fields");

                var updatedUser = await _userService.UpdateUserAsync(id, user.Name, user.Adedress, user.Email);
                
                if (updatedUser == null)
                    return NotFound($"User with ID {id} not found");

                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

      

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid user ID");

                var result = await _userService.DeleteUserAsync(id);
                
                if (!result)
                    return NotFound($"User with ID {id} not found");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
