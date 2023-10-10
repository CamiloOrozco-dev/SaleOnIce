using SaleOnIce.Models;

namespace SaleOnIce.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> UpdateRangeAsync(List<Product> products);
    }
}