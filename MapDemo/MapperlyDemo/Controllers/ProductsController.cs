using MapDemo.MapperlyDemo.Mappings;
using MapDemo.Shared.Domain;
using MapDemo.Shared.Dtos;
using MapDemo.Shared.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MapDemo.MapperlyDemo.Controllers {
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase {
        private readonly IProductStorage _productStorage;
        private readonly ProductMapper _mapper;

        public ProductsController(IProductStorage productStorage, ProductMapper mapper) {
            _productStorage = productStorage ?? throw new ArgumentNullException(nameof(productStorage));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<List<ProductDto>> Get() {
            var products = _productStorage.Get();

            var productsToReturn = _mapper.ToDtos(products.ToList());

            return Ok(productsToReturn);
        }
    }
}
