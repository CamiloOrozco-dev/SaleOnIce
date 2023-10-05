using Microsoft.EntityFrameworkCore;
using SaleOnIce.Models;

namespace SaleOnIce.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(SaleOnIceContext context) : base(context)
        {
             
        }

      
    }
}