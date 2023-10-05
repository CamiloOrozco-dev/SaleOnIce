using SaleOnIce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOnIce.Services 
{ 
    public interface IProductServices 
    {

        Task<List<Product>> GetProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<Product> AddProductAsync(Product product);
        Task<Product?> PutProductAsync(Product product, int id);
        Task DeleteProductAsync(int id);
         bool ProductIsInStock(int quantity, int id);

    }
}
