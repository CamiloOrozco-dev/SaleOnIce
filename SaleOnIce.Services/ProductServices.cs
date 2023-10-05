using SaleOnIce.Models;
using SaleOnIce.Repository;

namespace SaleOnIce.Services

{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;

        public ProductServices(IProductRepository repository) { 
            _productRepository = repository;
        }

        public async Task<List<Product>> GetProductsAsync() 
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                throw new KeyNotFoundException($"Product with id {id} not found");
            return product;
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            return await _productRepository.SaveAsync(product);
        }

        public async Task<Product?> PutProductAsync(Product product, int id)
        {
            bool productExist = await _productRepository.ExistsAsync(id);
            if (!productExist)
                throw new KeyNotFoundException($"Product with id {id} not found");
            return await _productRepository.UpdateAsync(id, product);
        }

        public async Task DeleteProductAsync(int id)
        {
            bool productExist = await _productRepository.ExistsAsync(id);
            if (!productExist)
                throw new KeyNotFoundException($"Product with id {id} not found");
            await _productRepository.DeleteAsync(id);
        }

        //END BASIC CRUD
        public bool ProductIsInStock(int quantity, int id)
        {
            throw new NotImplementedException();
        }
    }
}