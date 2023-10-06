using SaleOnIce.Models.DTOs;
using SaleOnIce.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOnIce.Models
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
                Quantity = dto.Quantity
            };
        }

        public ProductDto EntityToDTO(Product entity)
        {
            return new ProductDto
            {
                Id = entity.Id,
                NameProduct = entity.Name,
                ImageProduct = entity.Image,
                Description = entity.Description,
                PreviousPrice = entity.PreviousPrice,
                Price = entity.Price,
                Quantity = entity.Quantity
            };
        }
    }
}
