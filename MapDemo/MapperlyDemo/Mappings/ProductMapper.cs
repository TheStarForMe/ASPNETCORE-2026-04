using MapDemo.Shared.Domain;
using MapDemo.Shared.Dtos;
using Riok.Mapperly.Abstractions;

namespace MapDemo.MapperlyDemo.Mappings {
    [Mapper]
    public partial class ProductMapper {
        [MapperIgnoreSource(nameof(Product.Notes))]
        public partial ProductDto ToDto(Product product);


        public partial List<ProductDto> ToDtos(List<Product> products);


        [MapPropertyFromSource(nameof(FeatureDto.Text), Use = nameof(MapFeatureText))]
        public partial FeatureDto ToDto(Feature feature);

        private static string MapFeatureText(Feature feature) {
            return $"** {feature.Key}: {feature.Value} --";
        }
    }


    [Mapper]
    public partial class FeatureMapper {
        [MapProperty(nameof(Feature.Key), nameof(FeatureDto.Text), Use = nameof(MapFeatureText))]
        public partial FeatureDto ToDto(Feature feature);

        // kind of silly, we dont use mapperly for this, but it shows that we can use the same mapping method in multiple mappers
        public FeatureDto ToDto_v2(Feature feature) {
            return new FeatureDto {
                Text = MapFeatureText(feature)
            };
        }

        public static string MapFeatureText(Feature feature) {
            return $"** {feature.Key}: {feature.Value} --";
        }
    }
}
