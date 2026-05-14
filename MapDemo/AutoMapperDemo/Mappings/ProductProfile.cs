using AutoMapper;
using MapDemo.Shared.Domain;
using MapDemo.Shared.Dtos;

namespace MapDemo.AutoMapperDemo.Mappings {
    public class ProductProfile : Profile {
        public ProductProfile() {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDtoForCreate, Product>();
            CreateMap<ProductDtoForUpdate, Product>();

            CreateMap<Feature, FeatureDto>()
                .ForMember(
                    dest => dest.Text, 
                    opt => opt.MapFrom(src => $"** {src.Key}: {src.Value} **"));
        }
    }
}
