using Microsoft.AspNetCore.Mvc;
using SaleOnIce.Services;

namespace SaleOnIce.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ShoppinCartController : ControllerBase
    {
        private readonly IShoppingCartServices _services;

        public ShoppinCartController(IShoppingCartServices shoppingCartServices) {
            
            _services = shoppingCartServices;
        }

        [HttpGet("{id}")]
        public void Get(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public void Put()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public void Delete()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public void Post()
        {
            throw new NotImplementedException();
        }
    }
}