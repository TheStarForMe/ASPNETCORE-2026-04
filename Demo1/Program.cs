
using Microsoft.AspNetCore.StaticFiles;

namespace Demo1 {
    public class Program {
        public static void Main(string[] args) {
            //MyLogger logger = new MyLogger();

            //Class1 c1 = new Class1(logger);
            //Class2 c2 = new Class2(logger);


            var builder = WebApplication.CreateBuilder(args);
            
            //builder.Logging.ClearProviders();
            //builder.Logging.AddConsole();

            // Add services to the container.

            builder.Services.AddControllers(o => {
                // o.ReturnHttpNotAcceptable = true;
            })
                .AddNewtonsoftJson()
                .AddXmlDataContractSerializerFormatters();


            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddSwaggerGen();

            // add the FileExtensionContentTypeProvider as a singleton service to be injected into the FilesController
            builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

            //builder.Services.AddProblemDetails(o => {
            //    o.CustomizeProblemDetails = (ctx) => {
            //        ctx.ProblemDetails.Extensions.Add("ApplicationName", "My Demo API");
            //        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")?.ToUpper() == "DEVELOPMENT") {
            //            ctx.ProblemDetails.Extensions.Add("MachineName", Environment.MachineName);
            //        }
            //    };
            //});

            var app = builder.Build();


            //app.Run(async (context) => {
            //    await context.Response.WriteAsync("<html><body><b>Hello World!</b></body></html>");
            //});

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.MapOpenApi();
            
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //app.UseAuthorization();

            app.MapControllers();            

            //app.Run(async (context) => {
            //    await context.Response.WriteAsync("<html><body><b>Login:...</b></body></html>");
            //});

            app.Run();
        }
    }

    //internal class Class1 {
    //    private readonly MyLogger _logger;

    //    public Class1(MyLogger logger) {
    //        _logger = logger;

    //        Child = new Class3(logger);
    //    }

    //    public int ID { get; set; }

    //    public string Name { get; set; }

    //    public void DoSomething() {
    //        Console.WriteLine("Something");
    //        _logger.Write("Did something in Class1");
    //    }

    //    public Class3 Child { get; set; };
    //}

    //internal class Class2 {
    //    private readonly MyLogger _logger;

    //    public Class2(MyLogger logger) {
    //        _logger = logger;
    //    }

    //    public int ID { get; set; }

    //    public string Name { get; set; }

    //    public void DoSomething() {
    //        Console.WriteLine("Something");
    //        _logger.Write("Did something in Class2");
    //    }
    //}


    //internal class Class3 {
    //    private readonly MyLogger _logger;

    //    public Class3(MyLogger logger) {
    //        _logger = logger;
    //    }

    //    public int ID { get; set; }

    //    public string Name { get; set; }

    //    public void DoSomething() {
    //        Console.WriteLine("Something");
    //        _logger.Write("Did something in Class2");
    //    }
    //}


    //internal class MyLogger {
    //    public void Write(string message) {
    //        Console.WriteLine(message);
    //    }
    //}
}
