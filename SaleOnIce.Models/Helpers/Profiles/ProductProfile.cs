using AutoMapper;
using SaleOnIce.Models.DTOs;

namespace SaleOnIce.Models.Helpers.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()

             .ForMember(dest => dest.NameProduct,
                opt => opt.MapFrom(src => src.Name))
             .ForMember(dest => dest.ImageProduct,
                opt => opt.MapFrom(src => src.Image)
             );


            CreateMap<ProductDto, Product>()


                  .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.NameProduct))
                  .ForMember(dest => dest.Image,
                opt => opt.MapFrom(src => src.ImageProduct))
                .ForMember(dest => dest.Id,
                opt => opt.Ignore())
            .ForMember(dest => dest.InStock,
                opt => opt.Ignore());

        }

    }
}
