using MapDemo.MapperlyDemo.Mappings;
using MapDemo.Shared.Repositories;

namespace MapDemo.MapperlyDemo {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Inject our data repository as a dependency
            builder.Services.AddSingleton<IProductStorage, ProductStorage>();

            builder.Services.AddSingleton<ProductMapper>();

            // add swagger for API documentation
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapControllers();

            app.Run();
        }
    }
}
