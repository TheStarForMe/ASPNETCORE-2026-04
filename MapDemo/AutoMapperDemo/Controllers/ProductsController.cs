
using MapDemo.Shared.Domain;
using MapDemo.Shared.Dtos;
using MapDemo.Shared.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MapDemo.AutoMapperDemo.Controllers {
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase {
        private readonly IProductStorage _productStorage;

        public ProductsController(IProductStorage productStorage) {
            _productStorage = productStorage ?? throw new ArgumentNullException(nameof(productStorage));
        }

        [HttpGet]
        public ActionResult<List<ProductDto>> Get() {
            var products = _productStorage.Get();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> Get(int id) {
            var product = _productStorage.Get(id);
            if (product == null) {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
