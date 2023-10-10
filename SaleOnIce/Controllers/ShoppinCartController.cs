using Microsoft.AspNetCore.Mvc;
using SaleOnIce.Models;
using SaleOnIce.Models.DTOs;
using SaleOnIce.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace SaleOnIce.Controllers
{
    [Route("api/[Controller]/[action]")]
    [ApiController]
    public class ShoppinCartController : ControllerBase
    {
        private readonly IShoppingCartServices _services;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppinCartController"/> class.
        /// </summary>
        /// <param name="shoppingCartServices"> The ShoppingCart Services</param>
        /// <param name="mapper">The AutoMapper instance for mapping between DTOs and entities.</param>

        public ShoppinCartController(IShoppingCartServices shoppingCartServices)
        {
            _services = shoppingCartServices;
        }

        ///<summary>
        ///Generate new purchase from shopping cart
        /// </summary>
        /// <param name="PurchaseDto">The DTO representing the purchase to add.</param>
        /// <returns>The added purchase.</returns>

        [HttpPost]
        [SwaggerOperation("Add a new product")]
        [SwaggerResponse(200, "The product was added successfully")]
        public async Task<ActionResult<Purchase>> PostAsync([FromBody] List<ProductDto> products)
        {
            try
            {
            return await _services.GeneratePurchase(products);

            } catch (Exception ex) {
                return StatusCode(500, $"An error occurred while fetching purchase: {ex.Message}");
            }
        }
    }
}