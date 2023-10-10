using SaleOnIce.Models.DTOs;
using SaleOnIce.Services;

namespace SaleOnIce.Models.Helpers
{
    public class ProductConverter : IConverter<Product, ProductDto>
    {
        public Product DTOToEntity(ProductDto dto)
        {
            return new Product
            {
                Name = dto.NameProduct,
                Image = dto.ImageProduct,
                Description = dto.Description,
                PreviousPrice = dto.PreviousPrice,
                Price = dto.Price,
                Quantity = dto.Quantity,
            };
        }

        public ProductDto EntityToDTO(Product product)
        {
            return new ProductDto
            {
                IdProduct = product.Id,
                NameProduct = product.Name,
                ImageProduct = product.Image,
                Description = product.Description,
                PreviousPrice = product.PreviousPrice,
                Price = product.Price,
                Quantity = product.Quantity,
                StatusStock = product.InStock
            };
        }

        public List<ProductDto> ListEntityToListDTO(List<Product> products)
        {
            List<ProductDto> listDto = new();

            foreach (var product in products)
            {
                var productDto = EntityToDTO(product);

                listDto.Add(productDto);
            }

            return listDto;
        }

        public List<Product> ListDTOToListEntity(List<ProductDto> productsDto)
        {
            List<Product> listEntity = new();

            foreach (var productDto in productsDto)
            {
                var product = DTOToEntity(productDto);

                listEntity.Add(product);
            }

            return listEntity;
        }
    }
}