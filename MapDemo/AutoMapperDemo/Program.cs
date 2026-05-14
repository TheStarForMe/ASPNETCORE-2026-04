using MapDemo.Shared.Repositories;

namespace AutoMapperDemo {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();


            // Inject our data repository as a dependency
            builder.Services.AddSingleton<IProductStorage, ProductStorage>();

            builder.Services.AddAutoMapper(_ => {
                // license: https://automapper.org/en/stable/Dependency-injection.html#aspnet-core
            }, typeof(Program));

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
