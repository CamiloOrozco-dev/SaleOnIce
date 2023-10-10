using Microsoft.AspNetCore.Mvc;
using SaleOnIce.Models;
using SaleOnIce.Models.DTOs;
using SaleOnIce.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace SaleOnIce.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[action]")]
    public class PurchaseController : Controller
    {
        private readonly IPurchaseServices _services;

        public PurchaseController(IPurchaseServices services)
        {
            _services = services;
        }

        /// <summary>
        ///  Gets all purchases as invoice [Purchases].
        /// </summary>
        /// <returns>A list of the available [purchases].</returns>

        [HttpGet]
        [SwaggerOperation("Get all purchase")]
        [ProducesResponseType(200, Type = typeof(List<PurchaseDto>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<PurchaseDto>>> GetAsync()
        {

            try
            {
            var purchases = await _services.GetPurchases();
            if (purchases == null || purchases.Count == 0)
                return NotFound();
            return Ok(purchases);

            } catch (Exception ex) {
                return StatusCode(500, $"An error occurred while fetching purchase: {ex.Message}");
            }
        }

        /// <summary>.
        /// Gets a purchase by its ID.
        /// </summary>
        /// <param name="id">The ID of the purchase to be obtained.</param>
        /// <returns>A PurchaseDto object that represents the purchase.</returns>
        [HttpGet("{id}")]
        [SwaggerOperation("Get purchase by ID")]
        [ProducesResponseType(200, Type = typeof(PurchaseDto))]
        [ProducesResponseType(404)]
        public async Task<ActionResult< PurchaseDto>> GetPurchaseById([FromRoute] int id)
        { 
            try
            {
                  var purchase =   await _services.GetPurchaseByIdAsync(id);
                if (id != purchase.Id)
                    return NotFound();

                      return Ok(purchase);

            } catch ( Exception ex){
                return StatusCode(500, $"An error o ccurred while fetching purchase: {ex.Message}");
            }
        }
    }
}