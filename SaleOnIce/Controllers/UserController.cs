using Microsoft.AspNetCore.Mvc;
using SaleOnIce.Models;
using SaleOnIce.Models.DTOs;
using SaleOnIce.Services;
using Swashbuckle.AspNetCore.Annotations;

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
            try
            {
                await _userServices.AddUserAsync(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching user: {ex.Message}");
            }
        }

        /// <summary>
        /// Add a new debitCard.
        /// </summary>
        /// <param name="debitCardDto">The DTO representing the debitCard to add.</param>
        /// <returns>The added debitCard.</returns>
        [HttpPost]
        [SwaggerOperation("Add a new debitCard")]
        [SwaggerResponse(200, "The debitCard was added successfully")]
        public async Task<ActionResult<DebitCard>> PostDebitCardAsync([FromBody] DebitCardDto debitCard)
        {
            try
            {
                DebitCard = await _services.AdddebitCardAsync(debitCard);
                return debitCard;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching debitCards: {ex.Message}");
            }
        }

        [HttpGet(Name = "GetAllUsers")]
        public async Task<ActionResult<List<User>>> GetAsync()
        {
            try
            {
                List<User> users = await _userServices.GetUsersAsync();
                if (users == null || users.Count == 0)
                    return NotFound();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching user: {ex.Message}");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<User?>> GetByIdAsync([FromRoute] int id)
        {
            try
            {
                var user = await _userServices.GetUserByIdAsync(id);
                if (user == null)
                    return NotFound(user.Id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching user: {ex.Message}");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<User?>> PutAsync([FromRoute] int id, [FromBody] User user)
        {
            try
            {
                var userExist = await _userServices.GetUserByIdAsync(id);
                if (userExist is null)
                    return NotFound(userExist?.Id);
                await _userServices.PutUserAsync(user, id);
                return Ok(userExist);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching user: {ex.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<User?>> DeleteAsync([FromRoute] int Id)

        {
            try
            {

            var user = await _userServices.GetUserByIdAsync(Id);
            if (user is null)
                await _userServices.DeleteUserAsync(Id);
            return NoContent();

            }catch (Exception ex) { 
            
                return StatusCode(500, $"An error occurred while fetching user: {ex.Message}");
            }
        }
    }
}