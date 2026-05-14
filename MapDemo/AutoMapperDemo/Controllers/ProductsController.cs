
using AutoMapper;
using MapDemo.Shared.Domain;
using MapDemo.Shared.Dtos;
using MapDemo.Shared.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MapDemo.AutoMapperDemo.Controllers {
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase {
        private readonly IProductStorage _productStorage;
        private readonly IMapper _mapper;

        public ProductsController(IProductStorage productStorage, IMapper mapper) {
            _productStorage = productStorage ?? throw new ArgumentNullException(nameof(productStorage));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<List<ProductDto>> Get() {
            var products = _productStorage.Get();
            
            var productDtos = _mapper.Map<List<ProductDto>>(products);

            return Ok(productDtos);
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
