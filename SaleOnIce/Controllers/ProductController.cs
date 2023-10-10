using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaleOnIce.Models;
using SaleOnIce.Models.DTOs;
using SaleOnIce.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace SaleOnIce.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[action]")]
    public class ProductController : ControllerBase

    {
        private readonly IProductServices _services;

        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="productServices">The product services.</param>
        /// <param name="mapper">The AutoMapper instance for mapping between DTOs and entities.</param>
        public ProductController(IProductServices productServices, IMapper mapper)
        {
            _services = productServices;
            _mapper = mapper;
        }

        /// <summary>
        /// Add a new product.
        /// </summary>
        /// <param name="productDto">The DTO representing the product to add.</param>
        /// <returns>The added product.</returns>
        [HttpPost]
        [SwaggerOperation("Add a new product")]
        [SwaggerResponse(200, "The product was added successfully")]
        public async Task<ActionResult<Product>> PostAsync([FromBody] ProductDto productDto)
        {
            try
            {
                Product product = await _services.AddProductAsync(productDto);
                return product;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching products: {ex.Message}");
            }
        }  

        /// <summary>
        /// Get all products.
        /// </summary>
        /// <returns>A list of ProductDto objects representing products.</returns>
        [HttpGet]
        [SwaggerOperation("Get all products")]
        [SwaggerResponse(200, "List of products", typeof(List<ProductDto>))]
        public async Task<ActionResult<List<ProductDto>>> GetAsync()
        {
            try
            {
                var products = await _services.GetProductsAsync();
                if (products == null)
                    return NotFound();

                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching products: {ex.Message}");
            }
        }

        /// <summary>.
        /// Gets a product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to be obtained.</param>
        /// <returns>A ProductDto object that represents the product.</returns>

        [HttpGet("{id:int}")]
        [SwaggerOperation("Get one product by Id")]
        [SwaggerResponse(200, "Product with Id:", typeof(ProductDto))]
        public async Task<ActionResult<ProductDto?>> GetByIdAsync([FromRoute] int id)
        {
            try
            {
                var product = await _services.GetProductByIdAsync(id);
                if (id != product?.IdProduct)

                    return NotFound();
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching products: {ex.Message}");
            }
        }

        /// <summary>
        /// Update a product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to update.</param>
        /// <param name="productDto">The DTO representing the updated product.</param>
        /// <returns>The updated product or an error response.</returns>

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Product?>> PutAsync([FromRoute] int id, [FromBody] ProductDto product)
        {
            try
            {
                var productExist = await _services.GetProductByIdAsync(id);
                if (id != product.IdProduct)
                    return NotFound();

                await _services.PutProductAsync(product, id);
                return Ok(productExist);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching products: {ex.Message}");
            }
        }

        /// <summary>
        /// Delete a product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to delete.</param>

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Product?>> DeleteAsync([FromRoute] int id)

        {
            try
            {
                var product = await _services.GetProductByIdAsync(id);
                if (product is null)
                    return NotFound();
                await _services.DeleteProductAsync(id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching products: {ex.Message}");
            }
        }
    }
}