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
    }
}
