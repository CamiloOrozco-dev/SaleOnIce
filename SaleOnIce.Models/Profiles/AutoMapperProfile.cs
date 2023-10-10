using AutoMapper;
using SaleOnIce.Models.DTOs;

namespace SaleOnIce.Models.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<List<Product>, List<ProductDto>>();
            CreateMap<Product, ProductDto>();
        }
    }
}