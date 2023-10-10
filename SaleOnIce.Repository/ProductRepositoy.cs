using SaleOnIce.Models;

namespace SaleOnIce.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(SaleOnIceContext context) : base(context)
        {
        }

        public async Task<List<Product>> UpdateRangeAsync(List<Product> products)
        {
            _context.Products.UpdateRange(products);
            await _context.SaveChangesAsync();

            return products;
        }
    }
}