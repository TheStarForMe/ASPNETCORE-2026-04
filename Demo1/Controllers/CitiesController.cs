using Demo1.DataStores;
using Demo1.DbContexts;
using Demo1.DTO;
using Demo1.Services;
using Demo1.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using Serilog.Context;

namespace Demo1.Controllers {
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase {
        private readonly ILogger<CitiesController> _logger;
        private readonly IEmailService _email;
        private readonly ICityRepository _cityRepository;

        public CitiesController(ILogger<CitiesController> logger, IEmailService email, ICityRepository cityRepository) {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _email = email ?? throw new ArgumentNullException(nameof(email));
            _cityRepository = cityRepository ?? throw new ArgumentNullException(nameof(cityRepository));
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityWithoutLandmarksDTO>>> GetCities() {
            //_logger.LogInformation("No Property here");
            //using (LogContext.PushProperty("Simon", Guid.NewGuid())) {
            //    _email.Send("Getting all cities", "Getting all cities was called.");

            //    _logger.LogInformation("Getting all cities");
            //    _logger.LogInformation("Returned {CityCount} cities", CitiesDataStore.Current.Count);

            //    _email.Send("All cities were accessed", $"All cities were accessed at {DateTime.UtcNow}.");

            //    return CitiesDataStore.Current;
            //}


            var cities = new List<CityWithoutLandmarksDTO>();

            foreach (var city in await _cityRepository.GetCitiesAsync()) {
                cities.Add(new CityWithoutLandmarksDTO() {
                    ID = city.Id,
                    Name = city.Name,
                    Description = city.Description
                });
            }

            return Ok(cities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CityDTO>> GetCity(int id) {
            
            var city = await _cityRepository.GetCityAsync(id, false);

            if (city == null) {
                return NotFound();
            }

            CityDTO cityDto = new CityDTO() {
                ID = city.Id,
                Name = city.Name,
                Description = city.Description,
                LandMarks = city.LandMarks.Select(l => new LandMarkDTO() {
                    ID = l.Id,
                    Name = l.Name,
                    Description = l.Description
                })
            };

            return Ok(cityDto);

            //var city = CitiesDataStore.
            //    Current.
            //    FirstOrDefault(c => c.ID == id);

            //if (city == null) {
            //    return NotFound();
            //}

            //_email.Send("City was accessed", $"City with id: {id} was accessed.");

            //return city;
        }

        [HttpGet("problem/{id}")]
        public ActionResult MakeAProblem(int id) {

            var problem = new ProblemDetails() {
                Title = "This is a problem",
                Detail = "This is a detailed description of the problem",
                //Status = 301
            };

            return BadRequest(problem);

            //return Problem($"An error with id: {id}", "An Instance", 456);
        }
    }   
}