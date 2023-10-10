using SaleOnIce.Models;
using SaleOnIce.Models.DTOs;

namespace SaleOnIce.Services
{
    public interface IProductServices
    {
        Task<List<ProductDto>> GetProductsAsync();

        Task<ProductDto> GetProductByIdAsync(int id);

        Task<Product> AddProductAsync(ProductDto product);

        Task<Product?> PutProductAsync(ProductDto product, int id);

        Task DeleteProductAsync(int id);

        Task<List<Product>> UpdateProductStockAsync(List<ProductDto> products);
    }
}