using Demo1.DbContexts;
using Demo1.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo1.Services.Repositories {
    public class CityRepository : ICityRepository {
        private readonly MyMainContext _context;

        public CityRepository(MyMainContext context) {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ICollection<City>> GetCitiesAsync() {
            return await _context.Cities.ToListAsync();
        }
    }

    public interface ICityRepository {
        Task<ICollection<City>> GetCitiesAsync();
    }
}
