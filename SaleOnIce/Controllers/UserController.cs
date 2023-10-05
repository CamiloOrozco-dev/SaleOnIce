using Microsoft.AspNetCore.Mvc;
using SaleOnIce.Models;
using SaleOnIce.Services;

namespace SaleOnIce.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {

            _userServices = userServices;
        }

        [HttpPost(Name = "AddUser")]
        public async Task<ActionResult<User>> PostAsync([FromBody] User user)
        {
            await _userServices.AddUserAsync(user);

            return Ok(user);
        }

        [HttpGet(Name = "GetAllUsers")]
        public async Task<ActionResult<List<User>>> GetAsync()
        {
            List<User> users = await _userServices.GetUsersAsync();
            if (users == null || users.Count == 0)
                return NotFound();
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<User?>> GetByIdAsync([FromRoute] int id)
        {
            var user = await _userServices.GetUserByIdAsync(id);
            if (id != user?.Id)
                BadRequest();

            if (user == null)
                return NotFound(user.Id);
            return Ok(user);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<User?>> PutAsync([FromRoute] int id, [FromBody] User user)
        {
            if (id != user.Id)
                return BadRequest();

            var userExist = await _userServices.GetUserByIdAsync(id);
            if (userExist is null)
                return NotFound(userExist?.Id);


            await _userServices.PutUserAsync(user, id);
            return Ok(userExist);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<User?>> DeleteAsync([FromRoute] int Id)

        {
            var user = await _userServices.GetUserByIdAsync(Id);
            if (user is null)
                await _userServices.DeleteUserAsync(Id);
            return NoContent();
        }
    }
}