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

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

       [HttpPost]
public async Task<IActionResult> AddUsers([FromBody] User user)
{
    var newUser = await _userService.AddUserAsync(user.Name, user.Adedress, user.Email);
    return CreatedAtAction(nameof(GetAllUsers), new { id = newUser.Id }, newUser);
}

    }
}
