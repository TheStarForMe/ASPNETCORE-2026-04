using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers {
    [ApiController]
    public class CitiesController : ControllerBase {

        public IEnumerable<object> GetCities() {
            return new List<object>() {
                new { ID = 1, Name = "Tel-Aviv" },
                new { ID = 2, Name = "London" },
            };
        }
    }
}
