using Demo1.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo1.DbContexts {
    public class MyMainContext : DbContext {
        public MyMainContext(DbContextOptions options)
            : base(options) {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<LandMark> LandMarks { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        //    optionsBuilder.UseSqlite("Data Source=MyCities.db");
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<City>().HasData(
                new City("New York") {
                    Id = 1,
                    Description = "The city that never sleeps",
                    Population = 8419600,
                    Country = "USA"
                },
                new City("Paris") {
                    Id = 2,
                    Description = "The city of love",
                    Population = 2148000,
                    Country = "France",
                },
                new City("Tokyo") {
                    Id = 3,
                    Description = "The city of the rising sun",
                    Population = 13929000,
                    Country = "Japan"
                }
            );

            modelBuilder.Entity<LandMark>().HasData(
                new LandMark("Statue of Liberty") {
                    Id = 1,
                    CityId = 1,
                    Description = "A colossal neoclassical sculpture on Liberty Island in New York Harbor."
                },
                new LandMark("Empire State Building") {
                    Id = 2,
                    CityId = 1,
                    Description = "A 102-story Art Deco skyscraper in Midtown Manhattan, New York City."
                },
                new LandMark("Eiffel Tower") {
                    Id = 3,
                    CityId = 2,
                    Description = "A wrought-iron lattice tower on the Champ de Mars in Paris, France."
                },
                new LandMark("Louvre Museum") {
                    Id = 4,
                    CityId = 2,
                    Description = "The world's largest art museum and a historic monument in Paris, France."
                },
                new LandMark("Tokyo Tower") {
                    Id = 5,
                    CityId = 3,
                    Description = "A communications and observation tower in the Shiba-koen district of Minato, Tokyo, Japan."
                },
                new LandMark("Senso-ji Temple") {
                    Id = 6,
                    CityId = 3,
                    Description = "An ancient Buddhist temple located in Asakusa, Tokyo, Japan."
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
