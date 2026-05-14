using AutoMapper;
using MapDemo.Shared.Domain;
using MapDemo.Shared.Dtos;

namespace MapDemo.AutoMapperDemo.Mappings {
    public class ProductProfile : Profile {
        public ProductProfile() {
            CreateMap<Product, ProductDto>();
        }
    }
}
