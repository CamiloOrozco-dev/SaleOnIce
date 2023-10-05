using Microsoft.AspNetCore.Mvc;
using SaleOnIce.Models;
using SaleOnIce.Services;
using AutoMapper;
using SaleOnIce.Models.ViewModels.DTOs;

namespace SaleOnIce.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[action]")]
    public class ProductController : ControllerBase

    {
        private readonly IProductServices _services;

        private readonly IMapper _mapper; 
        public ProductController(IProductServices productServices, IMapper mapper)
        {
            _services = productServices;
            _mapper = mapper;
        }

        [HttpPost(Name = "AddProduct")]
        public async Task<ActionResult<Product>> PostAsync([FromBody] ProductDto productDto)
        {

            Product productMap = _mapper.Map<Product>(productDto);
            Product product = await _services.AddProductAsync(productMap);
            return product;

   
        }

        [HttpGet(Name = "GetAllProducts")]
        public async Task<ActionResult<List<ProductDto>>> GetAsync()
        {
           List<Product> products = await _services.GetProductsAsync();
            if (products == null || products.Count == 0)
               return NotFound();
     
            return Ok (products.Select(product => _mapper.Map<ProductDto>(products)));
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product?>> GetByIdAsync([FromRoute] int id)
        {
            var product = await _services.GetProductByIdAsync(id);
            if (id != product?.Id)
                BadRequest();

            if (product == null)
                return NotFound(product.Id);
            return Ok(product);
        }
            
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Product?>> PutAsync([FromRoute] int id, [FromBody] Product product)
        {
            if (id != product.Id)
                return BadRequest();

            var productExist = await _services.GetProductByIdAsync(id);
            if (productExist is null)
                return NotFound(productExist?.Id);


            await _services.PutProductAsync(product, id);
            return Ok(productExist);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Product?>> DeleteAsync([FromRoute] int id)

        {
            var product = await _services.GetProductByIdAsync(id); 
            if (product is null)
                return NotFound();

                await _services.DeleteProductAsync(id);
            return Ok(product);
        }
    }
}