using MapDemo.Shared.Domain;
using MapDemo.Shared.Dtos;
using Riok.Mapperly.Abstractions;

namespace MapDemo.MapperlyDemo.Mappings {
    [Mapper]
    public partial class ProductMapper {
        [MapperIgnoreSource(nameof(Product.Features))]
        [MapperIgnoreSource(nameof(Product.Notes))]
        public partial ProductDto ToDto(Product product);


        public partial List<ProductDto> ToDtos(List<Product> products);

    }

    //public partial class FeatureMapper {
    //    public partial FeatureDto ToDto(Feature feature);
    //}
}
