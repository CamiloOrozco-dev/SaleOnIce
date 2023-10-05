using AutoMapper;
using SaleOnIce.Models.ViewModels.DTOs;

namespace SaleOnIce.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
              CreateMap <Product, ProductDto>();
                   CreateMap<ProductDto, Product>();

        }

    }
}
