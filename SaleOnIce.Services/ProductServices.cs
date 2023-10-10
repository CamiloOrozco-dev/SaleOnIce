using SaleOnIce.Models;
using SaleOnIce.Models.DTOs;
using SaleOnIce.Repository;

namespace SaleOnIce.Services

{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;
        private readonly IConverter<Product, ProductDto> _converter;

        public ProductServices(IProductRepository repository, IConverter<Product, ProductDto> converter)
        {
            _productRepository = repository;
            _converter = converter;
        }

        public async Task<List<ProductDto>> GetProductsAsync()

        {
            var products = await _productRepository.GetAllAsync();
            var productsDto = _converter.ListEntityToListDTO(products);
            return productsDto;
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                throw new KeyNotFoundException($"Product with id {id} not found");
            var productDto = _converter.EntityToDTO(product);
            return productDto;
        }

        public async Task<Product> AddProductAsync(ProductDto product)
        {
            var productPost = _converter.DTOToEntity(product);
            //ImplementValidations
            return await _productRepository.SaveAsync(productPost);
        }

        public async Task<Product?> PutProductAsync(ProductDto product, int id)
        {
            var productPost = _converter.DTOToEntity(product);
            bool productExist = await _productRepository.ExistsAsync(id);
            if (!productExist)
                throw new KeyNotFoundException($"Product with id {id} not found");
            return await _productRepository.UpdateAsync(id, productPost);
        }

        public async Task DeleteProductAsync(int id)

        {
            bool productExist = await _productRepository.ExistsAsync(id);
            if (!productExist)
                throw new KeyNotFoundException($"Product with id {id} not found");
            await _productRepository.DeleteAsync(id);
        }

        //END BASIC CRUD

        public async Task<List<Product>> UpdateProductStockAsync(List<ProductDto> products)
        {
            var productDb = await _productRepository.GetAllAsync();
            List<Product> productsToUpdate = new List<Product>();
            foreach (var product in products)
            {
                var productMatch = productDb.FirstOrDefault(p => p.Id == product.IdProduct);

                if (productMatch != null)
                {
                    productMatch.Quantity -= product.CountProduct;
                    if (productMatch.Quantity >= 0)

                        productsToUpdate.Add(productMatch);
                }
            }

            return await _productRepository.UpdateRangeAsync(productsToUpdate);
        }
    }
}